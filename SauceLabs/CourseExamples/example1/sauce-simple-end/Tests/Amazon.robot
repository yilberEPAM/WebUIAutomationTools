*** Settings ***
Documentation  A simple Amazon.com suite
Library  SeleniumLibrary

*** Variables ***
# These variables can be overriden on the command line
${BROWSER} =  chrome
${START_URL} =  https://www.amazon.com

# Use this terminal command to RUN
# robot -d results tests/amazon.robot

*** Test Cases ***
Simple Web GUI Test
    [Documentation]  A simple Amazon.com test
    [Tags]  Smoke
    Open Browser  ${START_URL}  ${BROWSER}  remote_url=http://YOUR-SAUCE-USERNAME:YOUR-SAUCE-KEY@ondemand.saucelabs.com:80/wd/hub  desired_capabilities=name:Win 10 + Chrome 70,platform:Windows 10,browserName:chrome,version:70.0
    #Open Browser  ${START_URL}  ${BROWSER}  remote_url=http://YOUR-SAUCE-USERNAME:YOUR-SAUCE-KEY@ondemand.saucelabs.com:80/wd/hub  desired_capabilities=name:Win 10 + IE 11,platform:Windows 10,browserName:internet explorer,version:11.285
    Wait Until Page Contains  Careers
    Input Text  css=#twotabsearchtextbox  Ferrari 458
    Click Button  css=#nav-search > form > div.nav-right > div > input
    Wait Until Page Contains  results for
    Close Browser

*** Keywords ***
