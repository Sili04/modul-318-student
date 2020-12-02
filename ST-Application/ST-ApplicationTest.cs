using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST_Application
{
  [TestClass]
  public class STApplicationTest
  {
    VerbindungenSuchenForm application;

    [TestMethod]
    public void GenerateAutoCompleteSource()
    {
      application = new VerbindungenSuchenForm();
      IntellisenseController intellisenseController = new IntellisenseController();
      List<string> actual = intellisenseController.GenerateAutocompleteSource("Luzern");

      Assert.IsNotNull(actual);
    }
  }
}
