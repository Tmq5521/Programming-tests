import os
import sys

def inputStr(Display):
    #inital
    try:
        return input(Display)
    except BaseException:
        return "<<>>_Error_<<>>"
#end

commit = inputStr("Commit message: ")

print("\n{:+^40}".format("Add"))
os.system("git add *")

print("\n{:+^40}".format("Commit"))
os.system("git commit -m \""+commit+"\"")

print("\n{:+^40}".format("Push"))
os.system("git push")

print("\n{:+^40}".format("Pull"))
os.system("git pull")

print("\n{:+^40}".format("End"))
os.system("pause")

sys.exit()