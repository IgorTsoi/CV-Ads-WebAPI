﻿using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CV_Ads_WebAPI.Services
{
    public class LocalizationService : IStringLocalizer
    {
        private readonly Dictionary<string, Dictionary<string, string>> _resources;

        public LocalizationService()
        {
            Dictionary<string, string> enDictionary = GetEnglishLocalizationDictionary();
            Dictionary<string, string> uaDictionary = GetUkrainianLocalizationDictionary();

            CheckInitializationCorrectness(enDictionary, uaDictionary);

            _resources = new Dictionary<string, Dictionary<string, string>>
            {
                {"en", enDictionary },
                {"ua", uaDictionary }
            };
        }

        private void CheckInitializationCorrectness(
            Dictionary<string, string> enDictionary, Dictionary<string, string> uaDictionary)
        {
            if (enDictionary.Count != uaDictionary.Count)
            {
                throw new Exception(
                    "The initialization of localization service failed. The dictionaries have different number of strings.");
            }

            foreach (var pair in enDictionary)
            {
                if (!uaDictionary.ContainsKey(pair.Key))
                {
                    throw new Exception(
                        $"The initialization of localization service failed. Key in en dicitonary: {pair.Key}.");
                }
            }
        }

        private Dictionary<string, string> GetUkrainianLocalizationDictionary()
        {
            var dictionary = new Dictionary<string, string>();

            AddUkrainianValidationMessages(dictionary);

            return dictionary;
        }

        private Dictionary<string, string> GetEnglishLocalizationDictionary()
        {
            var dictionary = new Dictionary<string, string>();

            AddEnglishValidationMessages(dictionary);

            return dictionary;
        }

        private void AddUkrainianValidationMessages(Dictionary<string, string> dictionary)
        {
            dictionary.Add("The email is incorrect.", "Адреса електронної пошти введена некоректно.");
            dictionary.Add("The password field must not be empty.", "Пароль є обов'язковим для заповнення.");
            dictionary.Add("The first name field must not be empty.", "Ім'я є обов'язковим для заповнення.");
            dictionary.Add("The last name field must not be empty.", "Прізвище є обов'язковим для заповнення.");
            dictionary.Add("The serial number field must not be empty.", "Серійний номер є обов'язковим для заповнення.");
            dictionary.Add("The login field must not be empty.", "Логін є обов'язковим для заповнення.");
            dictionary.Add("The new password field must not be empty.", "Новий пароль є обов'язковим для заповнення.");
            dictionary.Add("The user with such login is already registered.", "Користувач з таким логіном вже зареєстрований у системі.");
            dictionary.Add("The user with such login doesn't exist", "Користувач з таким логіном не зареєстрований у системі.");
            dictionary.Add("The password is not correct", "Не правильний пароль.");
            dictionary.Add("Login failed. The user is not an admin.", "Помилка! Користувач не є адміністратором.");
            dictionary.Add("Login failed. The user is not a customer.", "Помилка! Користувач не є рекламодавцем.");
            dictionary.Add("Login failed. The user is not a partner.", "Помилка! Користувач не є партнером.");
            dictionary.Add("Login failed. The user is not a smart device.", "Помилка! Користувач не є розумним пристроєм.");
            dictionary.Add("The user with such id was not found.", "Користувача з таким ID немає в системі.");
            dictionary.Add("The user with such id is not a smart device.", "Користувача з таким ID не є розумним пристроєм.");
            dictionary.Add("The uploaded file is not valid.", "Файл не є валідним.");
            dictionary.Add("The gender is required.", "Стать є обов'язковою для заповнення.");
            dictionary.Add("The gender value provided is not supported.", "Стать не правильно задана.");
            dictionary.Add("The minimum age is required.", "Мінімальний вік є обов'язковим для заповнення.");
            dictionary.Add("The minimum age property cannot be less than 0.", "Мінімальний вік не може бути менше 0.");
            dictionary.Add("The maximum age is required.", "Максимальний вік є обов'язковим для заповнення.");
            dictionary.Add("The maximum age property cannot be greater than 100.", "Максимальний вік не може бути більше 100.");
            dictionary.Add("The 'from' field of time period is required.", "Поле 'від' в часовому обмеженні є обов'язковим.");
            dictionary.Add("The 'from' field of time period cannot be less than 0.", "Поле 'від' в часовому обмеженні не може бути менше 0.");
            dictionary.Add("The 'to' field of time period is required.", "Поле 'до' в часовому обмеженні є обов'язковим.");
            dictionary.Add("The 'to' field of time period cannot be greater than 1439.", "Поле 'до' в часовому обмеженні не може бути більше 1439.");
            dictionary.Add("The name is required.", "Ім'я є обов'язковим.");
            dictionary.Add("The views limit is required.", "Максимальна кількість переглядів є обов'язковою.");
            dictionary.Add("The views limit must be greater than 0.", "Максимальна кількість переглядів повинна бути більше ніж 0.");
            dictionary.Add("The time period limits is required.", "Обмеження часу є обов'язковими.");
            dictionary.Add("The human limits is required.", "Обмеження людського фактору є обов'язковими.");
            dictionary.Add("The advertisement with such id does not exist.", "Рекламного оголошення з таким ID не існує.");
            dictionary.Add("The advertisement with such id does not belong to current customer.", "Рекламне оголошення з таким ID не належить поточному користувачу.");
            dictionary.Add("New advertisement status is required.", "Поле 'новий статус для рекламного оголошення' є обов'язковим.");
            dictionary.Add("New advertisement status is incorrect.", "Таке значення поля 'новий статус для рекламного оголошення' не підтримується.");
            dictionary.Add("The age is required.", "Вік є обов'язковим для заповнення.");
            dictionary.Add("Faces is required", "Параметр 'Обличчя' є обов'язковим.");
            dictionary.Add("Country is required.", "Параметр 'Країна' є обов'язковим.");
            dictionary.Add("City is required.", "Параметр 'Місто' є обов'язковим.");
            dictionary.Add("Timezone offset is required.", "Параметр 'Зміщення часового поясу' є обов'язковим.");
            dictionary.Add("The smart device is not connected to the service.", "Розумний пристрій вимкнутий або не підключений до Інтернету.");
            dictionary.Add("The smart device cannot be activated.", "Розумний пристрій не може бути активований.");
            dictionary.Add("Caching mode must be specified.", "Режим кешування повинен бути заданий.");
            dictionary.Add("The power mode must be specified.", "Режим роботи екрану повинен бути заданий.");
            dictionary.Add("The smart device doesn't belong to user.", "Розумний пристрій не належить поточному користувачу.");
        }

        private void AddEnglishValidationMessages(Dictionary<string, string> dictionary)
        {
            dictionary.Add("The email is incorrect.", "The email is incorrect.");
            dictionary.Add("The password field must not be empty.", "The password field must not be empty.");
            dictionary.Add("The first name field must not be empty.", "The first name field must not be empty.");
            dictionary.Add("The last name field must not be empty.", "The last name field must not be empty.");
            dictionary.Add("The serial number field must not be empty.", "The serial number field must not be empty.");
            dictionary.Add("The login field must not be empty.", "The login field must not be empty.");
            dictionary.Add("The new password field must not be empty.", "The new password field must not be empty.");
            dictionary.Add("The user with such login is already registered.", "The user with such login is already registered.");
            dictionary.Add("The user with such login doesn't exist", "The user with such login doesn't exist");
            dictionary.Add("The password is not correct", "The password is not correct");
            dictionary.Add("Login failed. The user is not an admin.", "Login failed. The user is not an admin.");
            dictionary.Add("Login failed. The user is not a customer.", "Login failed. The user is not a customer.");
            dictionary.Add("Login failed. The user is not a partner.", "Login failed. The user is not a partner.");
            dictionary.Add("Login failed. The user is not a smart device.", "Login failed. The user is not a smart device.");
            dictionary.Add("The user with such id was not found.", "The user with such id was not found.");
            dictionary.Add("The user with such id is not a smart device.", "The user with such id is not a smart device.");
            dictionary.Add("The uploaded file is not valid.", "The uploaded file is not valid.");
            dictionary.Add("The gender is required.", "The gender is required.");
            dictionary.Add("The gender value provided is not supported.", "The gender value provided is not supported.");
            dictionary.Add("The minimum age is required.", "The minimum age is required.");
            dictionary.Add("The minimum age property cannot be less than 0.", "The minimum age property cannot be less than 0.");
            dictionary.Add("The maximum age is required.", "The maximum age is required.");
            dictionary.Add("The maximum age property cannot be greater than 100.", "The maximum age property cannot be greater than 100.");
            dictionary.Add("The 'from' field of time period is required.", "The 'from' field of time period is required.");
            dictionary.Add("The 'from' field of time period cannot be less than 0.", "The 'from' field of time period cannot be less than 0.");
            dictionary.Add("The 'to' field of time period is required.", "The 'to' field of time period is required.");
            dictionary.Add("The 'to' field of time period cannot be greater than 1439.", "The 'to' field of time period cannot be greater than 1439.");
            dictionary.Add("The name is required.", "The name is required.");
            dictionary.Add("The views limit is required.", "The views limit is required.");
            dictionary.Add("The views limit must be greater than 0.", "The views limit must be greater than 0.");
            dictionary.Add("The time period limits is required.", "The time period limits is required.");
            dictionary.Add("The human limits is required.", "The human limits is required.");
            dictionary.Add("The advertisement with such id does not exist.", "The advertisement with such id does not exist.");
            dictionary.Add("The advertisement with such id does not belong to current customer.", "The advertisement with such id does not belong to current customer.");
            dictionary.Add("New advertisement status is required.", "New advertisement status is required.");
            dictionary.Add("New advertisement status is incorrect.", "New advertisement status is incorrect.");
            dictionary.Add("The age is required.", "The age is required.");
            dictionary.Add("Faces is required", "Faces is required");
            dictionary.Add("Country is required.", "Country is required.");
            dictionary.Add("City is required.", "City is required.");
            dictionary.Add("Timezone offset is required.", "Timezone offset is required.");
            dictionary.Add("The smart device is not connected to the service.", "The smart device is not connected to the service.");
            dictionary.Add("The smart device cannot be activated.", "The smart device cannot be activated.");
            dictionary.Add("Caching mode must be specified.", "Caching mode must be specified.");
            dictionary.Add("The power mode must be specified.", "The power mode must be specified.");
            dictionary.Add("The smart device doesn't belong to user.", "The smart device doesn't belong to user.");
        }

        public LocalizedString this[string name]
        {
            get
            {
                var currentCulture = CultureInfo.CurrentCulture.Name;
                if (_resources.ContainsKey(currentCulture))
                {
                    if (_resources[currentCulture].ContainsKey(name))
                    {
                        return new LocalizedString(name, _resources[currentCulture][name]);
                    }
                    else
                    {
                        throw new Exception($"Localization failed. The localization string is not defined: '{name}'.");
                    }
                }
                else
                {
                    throw new Exception($"Localization failed. The culture is not supported: '{currentCulture}'.");
                }
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;
            return _resources[currentCulture].Select((pair) => new LocalizedString(pair.Key, pair.Value));
        }

        public LocalizedString this[string name, params object[] arguments] => this[name];

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return this;
        }
    }
}
