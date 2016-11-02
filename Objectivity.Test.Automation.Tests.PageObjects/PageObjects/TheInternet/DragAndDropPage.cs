// <copyright file="DragAndDropPage.cs" company="Objectivity Bespoke Software Specialists">
// Copyright (c) Objectivity Bespoke Software Specialists. All rights reserved.
// </copyright>
// <license>
//     The MIT License (MIT)
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//     The above copyright notice and this permission notice shall be included in all
//     copies or substantial portions of the Software.
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//     SOFTWARE.
// </license>

namespace Objectivity.Test.Automation.Tests.PageObjects.PageObjects.TheInternet
{
    using System;
    using System.Globalization;
    using Common.Extensions;
    using Common.Types;
    using Objectivity.Test.Automation.Common;
    using Objectivity.Test.Automation.Tests.PageObjects;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    public class DragAndDropPage : ProjectPageBase
    {
        private readonly ElementLocator
                cardSelectorPattern = new ElementLocator(Locator.Id, "card{0}"),
                cardLocationPattern = new ElementLocator(Locator.CssSelector, "div.ui-droppable:nth-of-type({0})"),
                message = new ElementLocator(Locator.Id, "successMessage");

        public DragAndDropPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public string GetMessage
        {
            get
            {
                return this.Driver.GetElement(this.message).Text;
            }
        }

        public DragAndDropPage DragAndDrop()
        {
            for (int a = 1; a <= 10; a++)
            {
                var source = this.Driver.GetElement(this.cardSelectorPattern.Format(a));
                var target = this.Driver.GetElement(this.cardLocationPattern.Format(a));
                new Actions(this.Driver).DragAndDrop(source, target).Perform();
            }

            return this;
        }
    }
}
