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

##
## Entry Point (if called from cmdline)
##
if __name__ == "__main__":
    socketio.run(app, host="localhost", port=500, debug=True)
