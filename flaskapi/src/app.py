import os
from flask import Flask, jsonify

app = Flask(__name__)

@app.route("/flask/<int:n>")
def getList(n):
  list = []
  for i in range(n):
    list.append(f"test {i}")
  return jsonify(list)

    
if __name__ == "__main__":
    app.run(port=5008, debug=False)