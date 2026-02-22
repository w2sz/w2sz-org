##
## Imports
##
from flask import Flask, render_template
from flask_minify import Minify
from flask_socketio import SocketIO

##
## Global Vars
##
app = Flask(__name__)
app.config['SECRET_KEY'] = 'f203f9m20doimpaops&*(@MD'
socketio = SocketIO(app, cors_allowed_origins="*")
# cssless is css or less not without css
Minify(app=app, html=True, js=True, cssless=True)

##
## Website Routes
##
@app.route("/", methods=["GET"])
def home():
    return render_template("index.html")
@app.route("/gallery", methods=["GET"])
def gallery():
    return render_template("gallery.html")
@app.route("/donate", methods=["GET"])
def donate():
    return render_template("donate.html")
@app.route("/officers", methods=["GET"])
def contact():
    return render_template("officers.html")
@app.route("/about", methods=["GET"])
def about():
    return render_template("about.html")
@app.route("/mgef", methods=["GET"])
def mgef():
    return render_template("mgef.html")
@app.route("/posts", methods=["GET"])
def posts():
    return render_template("posts.html")
@app.route("/logs", methods=["GET"])
def logbook():
    return render_template("logbook.html")

##
## Entry Point (if called from cmdline)
##
if __name__ == "__main__":
    socketio.run(app, host="localhost", port=500, debug=True)
