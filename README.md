# arcaptcha-dotnet
Arcaptcha library implementation in dotnet to validate captcha.


### Usage
Register on [Arcaptcha](https://arcaptcha.ir/), create website and get your own SiteKey and SecretKey

``` C#
           var website = ArcaptchaWebSite.Create("YOUR-SITE-KEY", "YOUR-SECRET-KEY");
           var isHuman = await  website.ValidateCaptchaAsync("CHALLENGE_ID");

```