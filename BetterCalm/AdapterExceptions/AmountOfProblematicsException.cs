﻿using System;
namespace AdapterExceptions
{
    public class AmountOfProblematicsException : Exception
    {
        private string errorMessage;

        public AmountOfProblematicsException()
        {
            this.errorMessage = "The amount of problematics is invalid. It's have to be four, please check.";
        }
    }
}
