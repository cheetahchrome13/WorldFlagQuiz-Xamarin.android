using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WorldFlagQuiz
{
	class MasterList
	{

		/// <summary>
		/// 
		/// </summary>		
		internal List<int> Images { get; } = new List<int>()
		{
			Resource.Drawable.Afghanistan, Resource.Drawable.AlandIslands, Resource.Drawable.Albania, Resource.Drawable.Algeria,
			Resource.Drawable.AmericanSamoa, Resource.Drawable.Andorra, Resource.Drawable.Angola, Resource.Drawable.Anguilla,
			Resource.Drawable.Antarctica, Resource.Drawable.AntiguaAndBarbuda, Resource.Drawable.Argentina, Resource.Drawable.Armenia,
			Resource.Drawable.Aruba, Resource.Drawable.Australia, Resource.Drawable.Austria, Resource.Drawable.Azerbaijan,
			Resource.Drawable.Bahamas, Resource.Drawable.Bahrain, Resource.Drawable.Bangladesh, Resource.Drawable.Barbados,
			Resource.Drawable.Belarus, Resource.Drawable.Belgium, Resource.Drawable.Belize, Resource.Drawable.Benin,
			Resource.Drawable.Bermuda, Resource.Drawable.Bhutan, Resource.Drawable.Bolivia, Resource.Drawable.Bonaire,
			Resource.Drawable.Bosnia, Resource.Drawable.Botswana, Resource.Drawable.Brazil, Resource.Drawable.BritishVirginIslands,
			Resource.Drawable.Brunei, Resource.Drawable.Bulgaria, Resource.Drawable.BurkinaFaso, Resource.Drawable.Burma,
			Resource.Drawable.Burundi,Resource.Drawable.Cambodia, Resource.Drawable.Cameroon, Resource.Drawable.Canada,
			Resource.Drawable.CapeVerde, Resource.Drawable.Cascadia, Resource.Drawable.CaymanIslands, Resource.Drawable.CentralAfricanRepublic,
			Resource.Drawable.Chad, Resource.Drawable.Chile, Resource.Drawable.China, Resource.Drawable.ChristmasIsland,
			Resource.Drawable.CocosIslands, Resource.Drawable.Colombia, Resource.Drawable.Comoros, Resource.Drawable.Congo,
			Resource.Drawable.CongoKinshasa, Resource.Drawable.CookIslands, Resource.Drawable.CostaRica, Resource.Drawable.Croatia,
			Resource.Drawable.Cuba, Resource.Drawable.Curacao, Resource.Drawable.Cyprus, Resource.Drawable.CzechRepublic,
			Resource.Drawable.Denmark, Resource.Drawable.Djibouti, Resource.Drawable.Dominica, Resource.Drawable.DominicanRepublic,
			Resource.Drawable.EastTimor, Resource.Drawable.Ecuador, Resource.Drawable.Egypt, Resource.Drawable.ElSalvador,
			Resource.Drawable.EquatorialGuinea, Resource.Drawable.Eritrea, Resource.Drawable.Estonia, Resource.Drawable.Ethiopia,
			Resource.Drawable.FalklandIslands, Resource.Drawable.FaroeIslands, Resource.Drawable.Fiji, Resource.Drawable.Finland,
			Resource.Drawable.France, Resource.Drawable.FrenchPolynesia, Resource.Drawable.FrenchSouthernTerritories, Resource.Drawable.Gabon,
			Resource.Drawable.Gambia, Resource.Drawable.Georgia, Resource.Drawable.Germany, Resource.Drawable.Ghana,
			Resource.Drawable.Gibraltar,Resource.Drawable.Greece, Resource.Drawable.Greenland, Resource.Drawable.Grenada,
			Resource.Drawable.Guadeloupe, Resource.Drawable.Guam, Resource.Drawable.Guatemala, Resource.Drawable.Guernsey,
			Resource.Drawable.Guinea, Resource.Drawable.GuineaBissau,Resource.Drawable.Guyana, Resource.Drawable.Haiti, Resource.Drawable.Honduras,
			Resource.Drawable.HongKong, Resource.Drawable.Hungary, Resource.Drawable.Iceland, Resource.Drawable.India, Resource.Drawable.Indonesia,
			Resource.Drawable.Iran, Resource.Drawable.Iraq, Resource.Drawable.Ireland, Resource.Drawable.IsleOfMan, Resource.Drawable.Israel,
			Resource.Drawable.Italy, Resource.Drawable.IvoryCoast, Resource.Drawable.Jamaica, Resource.Drawable.Japan, Resource.Drawable.Jordan,
			Resource.Drawable.Kazakhstan, Resource.Drawable.Kenya, Resource.Drawable.Kiribati, Resource.Drawable.Korea, Resource.Drawable.Kosovo,
			Resource.Drawable.Kuwait, Resource.Drawable.Kyrgyzstan,Resource.Drawable.Laos, Resource.Drawable.Latvia, Resource.Drawable.Lebanon,
			Resource.Drawable.Lesotho, Resource.Drawable.Liberia, Resource.Drawable.Libya, Resource.Drawable.Liechtenstein,
			Resource.Drawable.Lithuania, Resource.Drawable.Luxembourg, Resource.Drawable.Macau, Resource.Drawable.Macedonia,
			Resource.Drawable.Madagascar, Resource.Drawable.Malawi, Resource.Drawable.Malaysia, Resource.Drawable.Maldives, Resource.Drawable.Mali,
			Resource.Drawable.Malta, Resource.Drawable.MarshallIslands, Resource.Drawable.Martinique, Resource.Drawable.Mauritania,
			Resource.Drawable.Mauritius, Resource.Drawable.Mayotte, Resource.Drawable.Mexico, Resource.Drawable.Micronesia,
			Resource.Drawable.Moldova, Resource.Drawable.Monaco, Resource.Drawable.Mongolia, Resource.Drawable.Montenegro,
			Resource.Drawable.Montserrat, Resource.Drawable.Morocco, Resource.Drawable.Mozambique, Resource.Drawable.Myanmar,
			Resource.Drawable.Namibia, Resource.Drawable.Nauru, Resource.Drawable.Nepal, Resource.Drawable.Netherlands,
			Resource.Drawable.NetherlandsAntilles, Resource.Drawable.NewCaledonia, Resource.Drawable.NewZealand, Resource.Drawable.Nicaragua,
			Resource.Drawable.Niger, Resource.Drawable.Nigeria, Resource.Drawable.Niue, Resource.Drawable.NorfolkIsland,
			Resource.Drawable.NorthernIreland, Resource.Drawable.NorthKorea, Resource.Drawable.Norway, Resource.Drawable.Oman,
			Resource.Drawable.Pakistan, Resource.Drawable.Palau,Resource.Drawable.Palestine, Resource.Drawable.Panama,
			Resource.Drawable.PapuaNewGuinea, Resource.Drawable.Paraguay, Resource.Drawable.Peru, Resource.Drawable.Philippines,
			Resource.Drawable.Pitcairn, Resource.Drawable.Poland, Resource.Drawable.Portugal, Resource.Drawable.PuertoRico, Resource.Drawable.Qatar,
			Resource.Drawable.Reunion, Resource.Drawable.Romania, Resource.Drawable.Russia, Resource.Drawable.Rwanda,
			Resource.Drawable.SaintBarthelemy, Resource.Drawable.SaintEustatius, Resource.Drawable.SaintHelena,
			Resource.Drawable.SaintKittsAndNevis, Resource.Drawable.SaintLucia, Resource.Drawable.SaintMaarten, Resource.Drawable.SaintMartin,
			Resource.Drawable.SaintPierreAndMiquelon, Resource.Drawable.SaintVincentAndGrenadines, Resource.Drawable.Samoa,
			Resource.Drawable.SanMarino, Resource.Drawable.SaoTomeAndPrincipe, Resource.Drawable.SaudiArabia, Resource.Drawable.Scotland,
			Resource.Drawable.Senegal, Resource.Drawable.Serbia, Resource.Drawable.Seychelles, Resource.Drawable.SierraLeone,
			Resource.Drawable.Singapore, Resource.Drawable.Slovakia, Resource.Drawable.Slovenia, Resource.Drawable.SolomonIslands,
			Resource.Drawable.Somalia, Resource.Drawable.SouthAfrica, Resource.Drawable.SouthGeorgia, Resource.Drawable.SouthSudan,
			Resource.Drawable.Spain, Resource.Drawable.SriLanka, Resource.Drawable.Sudan, Resource.Drawable.Suriname, Resource.Drawable.Swaziland,
			Resource.Drawable.Sweden, Resource.Drawable.Switzerland, Resource.Drawable.Syria, Resource.Drawable.Taiwan,
			Resource.Drawable.Tajikistan, Resource.Drawable.Tanzania, Resource.Drawable.Thailand, Resource.Drawable.TimorLeste,
			Resource.Drawable.Togo, Resource.Drawable.Tokelau, Resource.Drawable.Tonga, Resource.Drawable.TrinidadAndTobago,
			Resource.Drawable.Tunisia, Resource.Drawable.Turkey, Resource.Drawable.Turkmenistan, Resource.Drawable.TurksAndCaicosIslands,
			Resource.Drawable.Tuvalu, Resource.Drawable.Uganda, Resource.Drawable.Ukraine, Resource.Drawable.UnitedArabEmirates,
			Resource.Drawable.UnitedKingdom, Resource.Drawable.UnitedStates, Resource.Drawable.Uruguay, Resource.Drawable.Uzbekistan,
			Resource.Drawable.Vanuatu, Resource.Drawable.VaticanCity, Resource.Drawable.Venezuela, Resource.Drawable.Vietnam,
			Resource.Drawable.VirginIslands, Resource.Drawable.Wales, Resource.Drawable.WallisAndFutuna, Resource.Drawable.WesternSahara,
			Resource.Drawable.Yemen, Resource.Drawable.Zambia, Resource.Drawable.Zimbabwe
		};

		/// <summary>
		/// 
		/// </summary>
		internal List<string> Names { get; } = new List<string>()
		{
			"Afganistan", "Aland Islands", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla", "Antarctica",
			"Antigua and Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain",
			"Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bonaire", "Bosnia",
			"Botswana", "Brazil", "British Virgin Islands", "Brunei", "Bulgaria", "Burkina-Faso", "Burma", "Burundi", "Cambodia",
			"Cameroon", "Canada", "Cape Verde", "Cascadia", "Cayman Islands", "Central African Republic", "Chad", "Chile", "China",
			"Christmas Island", "Cocos Islands", "Columbia", "Comoros", "Congo", "Congo Kinshasa", "Cook Islands", "Costa Rica",
			"Croatia", "Cuba", "Curacao", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominicana", "Dominican Republic",
			"East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Falkland Islands",
			"Faroe Islands", "Fiji", "Finland", "France", "French Polynesia", "French Southern Territories", "Gabon", "Gambia",
			"Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guernsey",
			"Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran",
			"Iraq", "Ireland", "Isle of Man", "Israel", "Italy", "Ivory Coast", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya",
			"Kiribati", "Korea", "Kosovo", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya",
			"Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali",
			"Malta", "Marshall Islands", "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Micronesia", "Moldova", "Monaco",
			"Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands",
			"Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island",
			"Northern Ireland", "North Korea", "Norway", "Oman", "Pakistan", "Palau", "Palestine", "Panama", "Papua New Guinea",
			"Paraguay", "Peru", "Philippines", "Pitcairn", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russia",
			"Rwanda", "Saint Barthelemy", "Saint Eustatius", "Saint Helena", "Saint Kitts and Nevis", "Saint Lucia", "Saint Maarten",
			"Saint Martin", "Saint Pierre and Miquelon", "Saint Vincent and Grenadines", "Samoa", "San Marino", "Sao Tome and Principe",
			"Saudi Arabia", "Scotland", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands",
			"Somalia", "South Africa", "South Georgia", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Swaziland", "Sweden",
			"Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Timor Leste", "Togo", "Tokelau", "Tonga",
			"Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Islands", "Tuvalu", "Uganda", "Ukraine",
			"United Arab Emirates", "United Kingdom", "United States", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City", "Venezuela",
			"Vietnam", "U.S. Virgin Islands", "Wales", "Wallis and Futuna", "Western Sahara", "Yemen", "Zambia", "Zimbabwe"
		};
	}
}

