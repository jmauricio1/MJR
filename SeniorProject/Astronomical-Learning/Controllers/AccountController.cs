using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Astronomical_Learning.Models;
using Astronomical_Learning.DAL;
using System.Collections.Generic;
using System.Diagnostics;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace Astronomical_Learning.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        public List<string> GetCountries(ref List<string> temp)
        {
            //A11
            temp.Add("Afghanistan");
            temp.Add("Albania");
            temp.Add("Algeria");
            temp.Add("Andorra");
            temp.Add("Angola");
            temp.Add("Antigua and Barbuda");
            temp.Add("Argentina");
            temp.Add("Armenia");
            temp.Add("Australia");
            temp.Add("Austria");
            temp.Add("Azerbaijan");

            //B19
            temp.Add("Bahamas, The");
            temp.Add("Bahrain");
            temp.Add("Bangladesh");
            temp.Add("Barbados");
            temp.Add("Belarus");
            temp.Add("Belgium");
            temp.Add("Belize");
            temp.Add("Benin(Dahomey)");
            temp.Add("Bermuda");
            temp.Add("Bhutan");
            temp.Add("Bolivia");
            temp.Add("Bosnia and Herzegovina");
            temp.Add("Botswana");
            temp.Add("Brazil");
            temp.Add("Brunei");
            temp.Add("Bulgaria");
            temp.Add("Burkina Faso");
            temp.Add("Burma");
            temp.Add("Burundi");

            //C17
            temp.Add("Cabo Verde");
            temp.Add("Cambodia");
            temp.Add("Cameroon");
            temp.Add("Canada");
            temp.Add("Cayman Islands, The");
            temp.Add("Central African Republic");
            temp.Add("Chad");
            temp.Add("Chile");
            temp.Add("China");
            temp.Add("Colombia");
            temp.Add("Comoros");
            temp.Add("Costa Rica");
            temp.Add("Cote d’Ivoire(Ivory Coast)");
            temp.Add("Croatia");
            temp.Add("Cuba");
            temp.Add("Cyprus");
            temp.Add("Czechia");

            //D5
            temp.Add("Democratic Republic of the Congo");
            temp.Add("Denmark");
            temp.Add("Djibouti");
            temp.Add("Dominica");
            temp.Add("Dominican Republic");

            //E9
            temp.Add("Ecuador");
            temp.Add("Egypt");
            temp.Add("El Salvador");
            temp.Add("Equatorial Guinea");
            temp.Add("Eritrea");
            temp.Add("Estonia");
            temp.Add("Eswatini");
            temp.Add("Ethiopia");

            //F3
            temp.Add("Faroe Islands (Isls Malvinas)");
            temp.Add("Fiji");
            temp.Add("Finland");
            temp.Add("France");
            temp.Add("French Polynesia");

            //G12
            temp.Add("Gabon");
            temp.Add("Gambia, The");
            temp.Add("Georgia");
            temp.Add("Germany");
            temp.Add("Ghana");
            temp.Add("Greece");
            temp.Add("Greenland");
            temp.Add("Grenada");
            temp.Add("Guatemala");
            temp.Add("Guinea");
            temp.Add("Guinea - Bissau");
            temp.Add("Guyana");

            //H4
            temp.Add("Haiti");
            temp.Add("Holy See");
            temp.Add("Honduras");
            temp.Add("Hungary");

            //I8
            temp.Add("Iceland");
            temp.Add("India");
            temp.Add("Indonesia");
            temp.Add("Iran");
            temp.Add("Iraq");
            temp.Add("Ireland");
            temp.Add("Israel");
            temp.Add("Italy");

            //J3
            temp.Add("Jamaica");
            temp.Add("Japan");
            temp.Add("Jordan");

            //K7
            temp.Add("Kazakhstan");
            temp.Add("Kenya");
            temp.Add("Kiribati");
            temp.Add("South Korea");
            temp.Add("Kosovo");
            temp.Add("Kuwait");
            temp.Add("Kyrgyzstan");

            //L
            temp.Add("Laos");
            temp.Add("Latvia");
            temp.Add("Lebanon");
            temp.Add("Lesotho");
            temp.Add("Liberia");
            temp.Add("Libya");
            temp.Add("Liechtenstein");
            temp.Add("Lithuania");
            temp.Add("Luxembourg");

            //M
            temp.Add("Madagascar");
            temp.Add("Malawi");
            temp.Add("Malaysia");
            temp.Add("Maldives");
            temp.Add("Mali");
            temp.Add("Malta");
            temp.Add("Marshall Islands");
            temp.Add("Mauritania");
            temp.Add("Mauritius");
            temp.Add("Mexico");
            temp.Add("Micronesia");
            temp.Add("Moldova");
            temp.Add("Monaco");
            temp.Add("Mongolia");
            temp.Add("Montenegro");
            temp.Add("Montserrat");
            temp.Add("Morocco");
            temp.Add("Mozambique");

            //N
            temp.Add("Namibia");
            temp.Add("Nauru");
            temp.Add("Nepal");
            temp.Add("Netherlands, The");
            temp.Add("New Caledonia");
            temp.Add("New Zealand");
            temp.Add("Nicaragua");
            temp.Add("Niger");
            temp.Add("Nigeria");
            temp.Add("North Macedonia");
            temp.Add("Norway");

            //O
            temp.Add("Oman");

            //P
            temp.Add("Pakistan");
            temp.Add("Palau");
            temp.Add("Panama");
            temp.Add("Papua New Guinea");
            temp.Add("Paraguay");
            temp.Add("Peru");
            temp.Add("Philippines");
            temp.Add("Poland");
            temp.Add("Portugal");
            temp.Add("Puerto Rico");

            //Q
            temp.Add("Qatar");

            //R
            temp.Add("Romania");
            temp.Add("Russia");
            temp.Add("Rwanda");

            //S26
            temp.Add("Saint Helena, Ascension, and Tristan da Cunha");
            temp.Add("Saint Kitts and Nevis");
            temp.Add("Saint Lucia");
            temp.Add("Saint Vincent and the Grenadines");
            temp.Add("Samoa");
            temp.Add("San Marino");
            temp.Add("Sao Tome and Principe");
            temp.Add("Saudi Arabia");
            temp.Add("Senegal");
            temp.Add("Serbia");
            temp.Add("Seychelles");
            temp.Add("SierraLeone");
            temp.Add("Singapore");
            temp.Add("Slovakia");
            temp.Add("Slovenia");
            temp.Add("Solomon Islands, The");
            temp.Add("Somalia");
            temp.Add("South Africa");
            temp.Add("South Sudan");
            temp.Add("Spain");
            temp.Add("Sri Lanka");
            temp.Add("Sudan");
            temp.Add("Suriname");
            temp.Add("Sweden");
            temp.Add("Switzerland");
            temp.Add("Syria");

            //T
            temp.Add("Taiwan");
            temp.Add("Tajikistan");
            temp.Add("Tanzania");
            temp.Add("Thailand");
            temp.Add("Timor - Leste");
            temp.Add("Togo");
            temp.Add("Tonga");
            temp.Add("Trinidad and Tobago");
            temp.Add("Tunisia");
            temp.Add("Turkey");
            temp.Add("Turkmenistan");
            temp.Add("Tuvalu");

            //U7
            temp.Add("Uganda");
            temp.Add("Ukraine");
            temp.Add("United Arab Emirates, The");
            temp.Add("United Kingdom, The");
            temp.Add("United States, The");
            temp.Add("Uruguay");
            temp.Add("Uzbekistan");

            //V3
            temp.Add("Vanuatu");
            temp.Add("Venezuela");
            temp.Add("Vietnam");

            //Y1
            temp.Add("Yemen");

            //Z2
            temp.Add("Zambia");
            temp.Add("Zimbabwe");


            Debug.WriteLine(temp[125] + temp[125].Count());
            return temp;
        }

        List<string> countryList = new List<string>();
        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {

            countryList = GetCountries(ref countryList);

            SelectList countryList2 = new SelectList(countryList);

            //List<CountryState> theList = GetListOfCountriesRegions();
            ViewBag.CountriesList = countryList2;
            ViewBag.DataKey = ConfigurationManager.AppSettings["ReCaptchaDataKey"];
            Debug.WriteLine(countryList);
            return View("Register");
        }

        private ALContext db = new ALContext();

        public string checkCaptcha(string key, string cResponse)
        {
            //create the url and request the information
            string url = "https://www.google.com/recaptcha/api/siteverify";
            string secretKey = "?secret=" + key;
            string check = "&response=" + cResponse;

            url = url + secretKey + check;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            //read in the information
            string jsonString = null;

            //try to get the information and if it fails return a default json string with an error picture and message
            try
            {


                using (WebResponse response = request.GetResponse())
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);
                    jsonString = reader.ReadToEnd();
                    reader.Close();
                    stream.Close();
                }
            }
            catch
            {
                jsonString = "false";
            }



            return jsonString;
        }





        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {


            string captchaResponse = Request.Form["g-Recaptcha-Response"];

            Debug.WriteLine("original response {0}", captchaResponse);

            if (captchaResponse == "")
            {
                ViewBag.Error = "Please check the reCaptcha checkbox";
                return View();
            }


            string secretKey = ConfigurationManager.AppSettings["ReCaptchaSecretKey"];

            string cResponse = checkCaptcha(secretKey, captchaResponse);


            Debug.WriteLine("capcha response {0}", cResponse);


            if (cResponse.Equals("false"))
            {
                ViewBag.Error = "There was an error with the response form the reCaptcha checkbox";
                return View();
            }



            JObject responseData = JObject.Parse(cResponse);

            string success = responseData["success"].ToString();

            Debug.WriteLine("check success {0}", success);

            if (success.Equals("false"))
            {
                ViewBag.Error = "There was an invalid response from the reCaptcha checkbox";
                return View();
            }





            if (ModelState.IsValid)
            {
                Random rand = new Random();
                int x = rand.Next(1, 7);
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Country = model.Country, StateProvince = model.StateProvince, AID = x};
                if(db.AspNetUsers.Any(m => m.UserName == user.UserName) == true)
                {
                    ViewBag.UsernameTaken = "Username already taken or unavailable.";
                    return View();
                }
                else
                {
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        UserManager.AddToRole(user.Id, "User");

                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                        // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                        // Send an email with this link
                        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                        return RedirectToAction("Index", "Home");
                    }
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }//
        #endregion
    }
}