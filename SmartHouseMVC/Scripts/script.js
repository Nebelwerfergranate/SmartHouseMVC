// Данные Css классы используются для работы скриптов.
// Их переименование обязательно должно быть синхронизировано с серверным кодом
//  js_AddButton
//	js_NewDeviceName
//  js_RenameButton
//  js_IClockDiv
//  js_dynamicClockDiv   
//  js_HoursSetField
//  js_MinutesSetField
//  js_SecondsSetField
//  js_TimeSetSubmit
//  js_ITemperatureDiv
//  js_MinTemperatureSpan
//  js_MaxTemperatureSpan
//  js_TemperatureSetSubmit
//  js_TemperatureSetField

function openDialog(id) {
    $("#clock-dialog").dialog('close');
    $("#microwave-dialog").dialog('close');
    $("#oven-dialog").dialog('close');
    $("#fridge-dialog").dialog('close');
    $("#" + id).dialog('open');
}

$(document).ready(function () {
    $("#clock-dialog").dialog({ autoOpen: false, title: "Add new clock" });
    $("#microwave-dialog").dialog({ autoOpen: false, title: "Add new microwave" });
    $("#oven-dialog").dialog({ autoOpen: false, title: "Add new oven" });
    $("#fridge-dialog").dialog({ autoOpen: false, title: "Add new fridge" });



//    $.scrollTo($.cookie("scrollTop"), 0);
//    // Device
//    $(".js_AddButton, .js_RenameButton").on("click", function (event) {
//        var name = prompt("Enter new device-container name", "");
//        if (name == null) {
//            event.preventDefault();
//            return;
//        }
//        document.getElementsByClassName("js_DeviceName")[0].value = name;
//    });

//    // IClock
//    $(".js_IClockDiv").each(function (index, value) {
//        var clockElement = $(value).find(".js_dynamicClockDiv:first");
//        var timestamp = $(value).find("input[type='hidden']:first").val();
//        var disabled = false;
//        if (timestamp == "disabled") {
//            disabled = true;
//        }
//        else {
//            timestamp = parseInt(timestamp);
//        }
//        $(clockElement).myClock({ "timestamp": timestamp, "disabled": disabled });

//        // Validation
//        var submitButton = $(value).find(".js_TimeSetSubmit:first");
//        $(submitButton).on("click", function (event) {
//            var hoursField = $(value).find(".js_HoursSetField:first");
//            var hours = hoursField[0].value;
//            var minutesField = $(value).find(".js_MinutesSetField:first");
//            var minutes = minutesField[0].value;
//            var inf = new Informer(event);

//            if (!validator.containsTwoDigits(hours)) {
//                inf.informUser("This field must contain digits", hoursField);
//                return;
//            }
//            hours = parseInt(hours);
//            if (!validator.hoursIsValid(hours)) {
//                inf.informUser("this field value is incorrect", hoursField);
//                return;
//            }

//            if (!validator.containsTwoDigits(minutes)) {
//                inf.informUser("This field must contain digits", minutesField);
//                return;
//            }
//            minutes = parseInt(minutes);
//            if (!validator.minutesIsValid(minutes)) {
//                inf.informUser("this field value is incorrect", minutesField);
//                return;
//            }
//        });
//    });

//    // ITimer
//    $(".js_ITimerDiv").each(function (index, value) {
//        var submitButton = $(value).find(".js_TimeSetSubmit:first");
//        $(submitButton).on("click", function (event) {
//            var inf = new Informer(event);
//            var hoursField = $(value).find(".js_HoursSetField:first");
//            if (hoursField[0] != undefined) {
//                var hours = hoursField[0].value;
//                if (!validator.containsTwoDigits(hours)) {
//                    inf.informUser("This field must contain digits", hoursField);
//                    return;
//                }
//                hours = parseInt(hours);
//                if (!validator.hoursIsValid(hours)) {
//                    inf.informUser("this field value is incorrect", hoursField);
//                    return;
//                }
//            }

//            var minutesField = $(value).find(".js_MinutesSetField:first");
//            var minutes = minutesField[0].value;
//            var secondsField = $(value).find(".js_SecondsSetField:first");
//            var seconds = secondsField[0].value;


//            if (!validator.containsTwoDigits(minutes)) {
//                inf.informUser("This field must contain digits", minutesField);
//                return;
//            }
//            minutes = parseInt(minutes);
//            if (!validator.minutesIsValid(minutes)) {
//                inf.informUser("this field value is incorrect", minutesField);
//                return;
//            }

//            if (!validator.containsTwoDigits(seconds)) {
//                inf.informUser("This field must contain digits", secondsField);
//                return;
//            }
//            seconds = parseInt(seconds);
//            if (!validator.secondsIsValid(seconds)) {
//                inf.informUser("this field value is incorrect", secondsField);
//                return;
//            }
//        });
//    });

//    // ITemperature
//    $(".js_ITemperatureDiv").each(function (index, value) {
//        var submitButton = $(value).find(".js_TemperatureSetSubmit:first");
//        var ITemperatureDiv = value;
//        var temperatureField = $(ITemperatureDiv).find(".js_TemperatureSetField:first")[0];
//        var minTemperature = getMinTemperature(ITemperatureDiv);
//        var maxTemperature = getMaxTemperature(ITemperatureDiv);
//        temperatureField.title = "Set value between " +
//                minTemperature + " and " + maxTemperature;

//        $(submitButton).on("click", function (event) {
//            var inf = new Informer(event);
//            var temperature = temperatureField.value;
//            if (!validator.temperatureFormatIsValid(temperature)) {
//                inf.informUser("Temperature format is not correct", temperatureField);
//                return;
//            }
//            temperature = parseInt(temperature);
//            if (!validator.temperatureValueIsValid(ITemperatureDiv, temperature)) {
//                inf.informUser("Temperature should be between " +
//                    minTemperature + " and " +
//                    maxTemperature, temperatureField);
//                return;
//            }
//        });
//    });

//    $.jGrowl.defaults.closerTemplate = '<div>hide all notifications</div>';

//    $(".js_RenameButton").each(function (index, value) {
//        value.title = "Rename device";
//    });

//    $(document).scroll(function() {
//        $.cookie("scrollTop" ,$(document).scrollTop());
//    });
});

//// Validator
//var validator = {
//    timeRegexp: /^[0-9]{1,2}$/,
//    temperatureRegexp: /(?:^-[0-9]{1,3}$)|(?:^[0-9]{1,4}$)/,
//    containsTwoDigits: function (userInput) {
//        return userInput.match(this.timeRegexp);
//    },
//    temperatureFormatIsValid: function (userInput) {
//        return userInput.match(this.temperatureRegexp);
//    },
//    secondsIsValid: function (userInput) {
//        var seconds = parseInt(userInput);
//        if (seconds < 0 || seconds > 59) {
//            return false;
//        }
//        else {
//            return true;
//        }
//    },
//    minutesIsValid: function (userInput) {
//        var minutes = parseInt(userInput);
//        if (minutes < 0 || minutes > 59) {
//            return false;
//        }
//        else {
//            return true;
//        }
//    },
//    hoursIsValid: function (userInput) {
//        var hours = parseInt(userInput);
//        if (hours < 0 || hours > 23) {
//            return false;
//        }
//        else {
//            return true;
//        }
//    },
//    temperatureValueIsValid: function (sender, userInput) {
//        var temperature = parseInt(userInput);
//        var minTemperature = getMinTemperature(sender);
//        minTemperature = parseInt(minTemperature);
//        var maxTemperature = getMaxTemperature(sender);
//        maxTemperature = parseInt(maxTemperature);
//        if (temperature <= maxTemperature && temperature >= minTemperature) {
//            return true;
//        }
//        else {
//            return false;
//        }
//    }
//}

//// Informer
//var Informer = function (event) {
//    this._event = event;
//}
//Informer.prototype.informUser = function (message, field) {
//    $.jGrowl(message);
//    $(field).stop(true).animate({ "backgroundColor": "red" }, 2000, "easeOutQuint").
//    animate({ "backgroundColor": "white" }, 2000, "easeInQuint");
//    this._event.preventDefault();
//}

//function getMinTemperature(iTemperatureDiv) {
//    return $(iTemperatureDiv).find(".js_MinTemperatureSpan input[type='hidden']:first").val();
//}

//function getMaxTemperature(iTemperatureDiv) {
//    return $(iTemperatureDiv).find(".js_MaxTemperatureSpan input[type='hidden']:first").val();
//}