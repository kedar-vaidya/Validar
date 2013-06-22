﻿using System;
using System.Collections;
using System.ComponentModel;

public class Person : IDataErrorInfo, INotifyPropertyChanged, INotifyDataErrorInfo
{
    ValidationTemplate validationTemplate;
    public string GivenNames;
    public string FamilyName;

    public Person()
    {
        validationTemplate = new ValidationTemplate(this);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    string IDataErrorInfo.this[string columnName]
    {
        get { return validationTemplate[columnName]; }
    }

    public string Error
    {
        get { return validationTemplate.Error; }
    }

    public IEnumerable GetErrors(string propertyName)
    {
        return validationTemplate.GetErrors(propertyName);
    }

    bool INotifyDataErrorInfo.HasErrors
    {
        get { return validationTemplate.HasErrors; }
    }
    event EventHandler<DataErrorsChangedEventArgs> INotifyDataErrorInfo.ErrorsChanged
    {
        add { validationTemplate.ErrorsChanged += value; }
        remove { validationTemplate.ErrorsChanged -= value; }
    }
}