*** Settings ***
Documentation  A simple Amazon.com suite
Library  SeleniumLibrary

*** Variables ***
# These variables can be overriden on the command line
${BROWSER} =  chrome
${START_URL} =  https://www.amazon.com
${REMOTE_URL} =  http://SAUCE-USER-NAME:SAUCE-KEY@ondemand.saucelabs.com:80/wd/hub
${DESIRED_CAPABILITIES} =  name:Win10 + Chrome 70,platform:Windows 10,browserName:chrome,version:70.0

# use this command to RUN
#robot -v REMOTE_URL:http://SAUCE-USER-NAME:SAUCE-KEY@ondemand.saucelabs.com:80/wd/hub -d results/Win10Chrome70 -v DESIRED_CAPABILITIES:"name:Win 10 + Chrome 70, platform:Windows 10,browserName:chrome,version:70.0" tests/amazon.robot

*** Test Cases ***
Simple Web GUI Test
    [Documentation]  A simple Amazon.com test
    [Tags]  Smoke
    Open Browser  ${START_URL}  ${BROWSER}  remote_url=${REMOTE_URL}  desired_capabilities=${DESIRED_CAPABILITIES}
    Wait Until Page Contains  Careers
    Input Text  css=#twotabsearchtextbox  Ferrari 458
    Click Button  css=#nav-search > form > div.nav-right > div > input
    Wait Until Page Contains  results for
    Close Browser

*** Keywords ***



