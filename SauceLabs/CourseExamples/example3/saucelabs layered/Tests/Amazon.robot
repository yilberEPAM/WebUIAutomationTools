*** Settings ***
Documentation  This is some basic info about the whole suite
Resource  ../Resources/Common.robot  # for Setup & Teardown
Resource  ../Resources/AmazonApp.robot  # for lower level keywords in test cases
Test Setup  Common.Begin Web Test
Test Teardown  Common.End Web Test

# ADD your sauce username and key, then use this command to RUN
# robot -d results/win7-ie11 -v REMOTE_URL:http://YOUR-SAUCE-USERNAME:YOUR-SAUCE-KEY@ondemand.saucelabs.com:80/wd/hub -v DESIRED_CAPABILITIES:"platform:Windows 10,browserName:chrome,version:70.0" tests/amazon.robot

*** Variables ***
${BROWSER} =  ie
${START_URL} =  https://www.amazon.com
${REMOTE_URL} =  http://YOUR-SAUCE-USERNAME:YOUR-SAUCE-KEY@ondemand.saucelabs.com:80/wd/hub
${DESIRED_CAPABILITIES} =  platform:Windows 10,browserName:chrome,version:70.0
${SEARCH_TERM} =  Ferrari 458

*** Test Cases ***
Logged out user can search for products
    [Tags]  Current
    AmazonApp.Search for Products

Logged out user must sign in to check out
    AmazonApp.Search for Products
    AmazonApp.Select Product from Search Results
    AmazonApp.Add Product to Cart
    AmazonApp.Begin Checkout
