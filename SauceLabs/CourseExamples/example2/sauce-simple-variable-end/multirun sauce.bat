ECHO Starting batch run at Saucelabs.com
cd C:\development\robot-scripts\sauce\simple-variable-end

ECHO Win7/Chrome40:
start pybot -v REMOTE_URL:http://SAUCE-USER-NAME:SAUCE-KEY@ondemand.saucelabs.com:80/wd/hub	-d results/Win7Chrome40 	-v DESIRED_CAPABILITIES:"name:Win 10 + Chrome 70, platform:Windows 10,browserName:chrome,version:70.0"	tests/amazon.robot

ECHO Win7/IE11:
start pybot -v REMOTE_URL:http://SAUCE-USER-NAME:SAUCE-KEY@ondemand.saucelabs.com:80/wd/hub	-d results/Win8IE11 		-v DESIRED_CAPABILITIES:"name:Win 10 + IE 11,platform:Windows 10,browserName:internet explorer,version:11.285" tests/amazon.robot

ECHO Linux/Chrome:
start pybot -v REMOTE_URL:http://SAUCE-USER-NAME:SAUCE-KEY@ondemand.saucelabs.com:80/wd/hub	-d results/LinuxChrome43 	-v DESIRED_CAPABILITIES:"name:Linux + Chrome 48, platform:Linux,browserName:chrome,version:48.0"		tests/amazon.robot

ECHO Mac/Safari:
start pybot -v REMOTE_URL:http://SAUCE-USER-NAME:SAUCE-KEY@ondemand.saucelabs.com:80/wd/hub	-d results/Mac10Safari8 	-v DESIRED_CAPABILITIES:"name:Mac Sierra + Safari 12, platform:macOS 10.13,browserName:safari,version:12.0" 	tests/amazon.robot
