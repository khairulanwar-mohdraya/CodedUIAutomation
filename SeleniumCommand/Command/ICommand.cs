using OpenQA.Selenium;

namespace SeleniumCommand.Command
{
    public interface ICommand
    {
        IWebDriver Driver();
        void Navigate(string pageName);
        void ClickByID(string elementID);
        void ClickByXPath(string xPath);
        void ClickByName(string name);
        void FillByID(string elementID, string value);
        void FillByName(string elementName, string value);
        string GetTextByID(string elementID);
        string GetTextByXPath(string elementID);
        string GetTextInFrame(By frame, By element);
        void SelectDropDownListTextByID(string elementID, string text);
        void SelectDropDownListValueByName(string elementName, string value);
		void SelectDropDownListValueByID(string elementID, string value);
		void FrameClickElement(By frame, By element);
        void DoubleFrameClickByID(string frameID1, string frameID2, string elementID);
        void WaitPageLoad(int seconds);
        void WaitElementDisappear(By by, int seconds);
        void WaitElementAppear(By by, int seconds);
        void SwitchWindow(int windowIndex);
        void Close();
        void Quit();
    }
}
