# Auto-fix for Touch Id, Print Id Touch printer.

## Explanation
 There's a problem on my restaurante with this specific model of thermal printers
where it print with a low print streght on paper.
 After take a look on her configuration panel i notice the "print head time" and "print quality" options,
when put on maximun the printer back to normal printing streght.
 But after some minutes it have a bug where it turns back to lowest values on config.

## Solution
 After some reverse engineering taking a look on web tcp configuration panel with Fiddler, i captured 
the http calls sent to printer to setup the configuration. So i wrote this script to turn easier to apply that settings.
