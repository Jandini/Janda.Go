@echo off
:: The code is using gitversion so it cannot be build without git commits.
:: This script will initialize this folder as git repository and add "Initial commit". 

:: initialize git repository with main branch
if not exist .git git init --initial-branch=main
if %errorlevel% neq 0 echo Git version 2.34 or above is required.&goto :eof

:: check if there are any commits
git log 2>nul 1>nul
if %errorlevel% equ 0 goto :eof
:: add all files and commit
git add -- .
git commit -m "Initial commit"

