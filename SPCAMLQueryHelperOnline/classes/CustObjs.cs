using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPCAMLQueryHelperOnline
{

    [Serializable]
    public class SessionObject
    {
        public string txtSiteUrl { get; set; }
        public string txtQuery { get; set; }
        public string txtViewFields { get; set; }
        public string txtViewAttributes { get; set; }
        public string txtRowLimit { get; set; }

        public string txtUsername { get; set; }
        public string txtPassword { get; set; }
        public string txtDomain { get; set; }

        public string appMode { get; set; }
    }

    public class CustXMLWeb
    {
        public string Title { get; set; } // ex. SubSite1
        public string Url { get; set; } // ex. http://athena/sites/LDH1/SubSite1
        public List<CustXMLList> Lists { get; set; }
    }

    public class CustXMLList
    {

        public string DefaultViewUrl { get; set; } // ex. /sites/LDH1/SubSite1/Lists/CustList1/AllItems.aspx
        public string ID { get; set; } // ex. {718E22A9-85F0-4786-8942-BEDEDDEE8A7A}
        public string Title { get; set; } // ex. CustList1
        public string Name { get; set; } // ex. {718E22A9-85F0-4786-8942-BEDEDDEE8A7A}
        public string WebFullUrl { get; set; } // ex. /sites/LDH1/SubSite1
        public string WebId { get; set; } // ex. b0192633-10a5-4bfa-a2cb-5ed23ae933f5
        public bool Hidden { get; set; } // ex. False

    }

    public class CustXMLView
    {
        public string Name { get; set; } // ex. {96FF8C4D-3EAC-41B3-9522-ECC2F6028CE1}
        public bool DefaultView { get; set; } // ex. TRUE
        public string DisplayName { get; set; } // ex. All Items
        public string Url { get; set; } // ex. /sites/LDH1/Lists/States/AllItems.aspx
    }

    public class CustXMLField
    {
        public string ID { get; set; } // ex. {fa564e0f-0c70-4ab9-b863-0177e6ddd247}
        public string Name { get; set; } // (internalName) ex. Title
        public bool Required { get; set; } // ex. TRUE
        public string DisplayName { get; set; } // (title) ex. Title
        public string Type { get; set; } // (typeAsString) ex. Text
    }

}
