# 라이브러리 임포트
from flask import Flask, jsonify, request, render_template
import json
from ast import literal_eval
import csv

firstVal = 0
secondVal = 0
peopleNum = 0


# __name=파일명
app = Flask(__name__)

# p5로 보내는 신호
serverText = ["python_HOST"]
clientText = {}
user = "Hello fromUnity"


# clientText=유니티로 보내는 신호

# 바탕화면


@app.route("/")
def home_page():
    return render_template("index.html")


# 또다른 페이지. 겟과 포스트를 수행하는
# def on_json_loading_failed_return_dict(e):
# return ""


@app.route("/test", methods=["GET", "POST"])
def testfn():

    # GET request

    if request.method == "GET":
        message = {"fromPython": serverText}
        return jsonify(message)  # serialize and use JSON headers
    # POST request
    if request.method == "POST":

        # 클라이언트들이 기록한 Json 로그를 다시 클라이언트들에게
        clientText = request.get_json()
        global firstVal
        global secondVal
        firstVal = clientText["greeting"]
        secondVal = clientText["greeting2"]

        print(type(firstVal), firstVal)
        print(type(secondVal), secondVal)

        # state_FromUnity=clientText['state_FromUnity']
        # foo=clientText['foo']

        # else:
        # print("greeting: NONE")

        # foo=clientText['foo']
        # print(greeting)
        # print(foo)

        serverText.append(firstVal)
        print(
            type(serverText),
            serverText,
        )

        print(len(serverText))

        # if(len[clientText]>50):

        # fromUnity=  request.form["fromUnity"]
        # print(fromUnity)
        # print("clientText",clientText,type(clientText))  # parse as JSON

        # fromUnity=request.form["fromUnity"]

        # print(fromUnity)
        # serverText.append(fromUnity)

        # parse as JSON

        global peopleNum
        text = str(secondVal)
        f = open(
            "//Users/marshmalloww/Desktop/savetofile/poseNet.csv",
            "a",
            encoding="utf-8",
            newline="",
        )
        wr = csv.writer(f)
        if peopleNum == 0:
            wr.writerow(["Num", "Val"])
            wr.writerow([peopleNum, text])

        else:
            wr.writerow([peopleNum, text])
        f.close()

        peopleNum += 1

        return "success", 200


# 서버 실행시키기
if __name__ == "__main__":
    # run!
    app.run(debug=True)
