export function displayAlert(message) {
    return alert(message);
}

export function myFunction(id) {
   document.body.style.backgroundColor = "red";
}

export function ReloadPage()
{
    window.location.reload(true);
}

export function CloseWindow()
{
    window.close();
}

export function GetDate() {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = mm + '/' + dd + '/' + yyyy;
}

export function DisplayImage(description) {
    var div = document.createElement('div');
    div.innerHTML = post_body;
    var firstImage = div.getElementsByTagName('img')[0]
    var imgSrc = firstImage ? firstImage.src : "";
    // or, if you want the unresolved src, as it appears in the original HTML:
    var rawImgSrc = firstImage ? firstImage.getAttribute("src") : "";
}