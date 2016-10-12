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

os.system("git add *")
print()
os.system("git commit -m \""+commit+"\"")
print()
os.system("git push")
print()
os.system("git pull")
print()
os.system("pause")
sys.exit()