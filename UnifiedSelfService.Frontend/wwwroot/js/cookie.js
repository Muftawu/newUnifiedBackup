function setCookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toDateString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

function getCookie(name) {
    var cookiename = name + "=";
    var cookie = document.cookie.split(";");
    for (var i = 0; i < cookie.length; i++) {
        var c = cookie[i];
        while (c.charAt(0) == " ")
            c = c.substring(1, c.length);
        if (c.indexOf(cookiename) == 0)
            return c.substring(cookiename.length, c.length);
    }
    return null;
}

function deleteCookie(name) {
    document.cookie = name + "=; Max-Age=-99999999";
}

function getFormFieldData(fieldId)
{
    const data = document.getElementById(fieldId);
    const data_value = data.value;
    console.log('data', data);
    console.log('data value', data.value);
    return data_value; 
}



