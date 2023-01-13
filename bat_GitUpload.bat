@echo off

rem Add all changes to the staging area
git add .

rem Ask user for commit message
set /p message=Enter commit message: 

rem list all branch
git branch

rem Ask user for branch
set /p branch=Which branch you want to commit to: 

rem switch to branch
git checkout %branch%

rem Commit the changes with user input message
git commit -m "%message%"

rem Push the changes to the remote repository
git push origin %branch%

pause