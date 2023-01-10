from os import path as pathh
import os

# folder path
dir_path = os.getcwd()

# list to store files
res = []

# Iterate directory
for path in os.listdir(dir_path):
    # check if current path is a file
    if os.path.isfile(os.path.join(dir_path, path)):
        res.append(path)

currentNumber=0
for file in res:
    if file!= "rename.py":
        dest=str(currentNumber)+".png"
        while(pathh.exists(dest)):
            currentNumber+=1
            dest=str(currentNumber)+".png"
        os.rename(file, dest)
        currentNumber+=1
print(res)
