namespace TEKUtsav.Infrastructure.Constants{	public static class Globals	{		public const string TEKUtsavAPPVERSION = "TEKUtsavAppVersionValue";		#region "URL"		public const string OKTA_SP_URL = "http://TEKUtsavoktaservice-dev.azurewebsites.net";//"http://203.176.153.150";		public const string OKTA_IDP_URL = "https://TEKUtsavsandbox.okta.com";		public const string COOKIE = ".AspNet.ExternalCookie";        public const string AZURE_URL = "http://tekutsavmobileserviceapi20180212085858.azurewebsites.net/";//"http://10.188.27.105:59488/";//"http://tekutsav2018.azurewebsites.net/";		public const string OKTA_USER_URL = "http://TEKUtsavoktaservice-dev.azurewebsites.net/Home";		public const string OKTAUSERDOMAIN = "TEKUtsavoktaservice-dev.azurewebsites.net";		//"http://TEKUtsavmobileservice-hmmobileservicedevslot.azurewebsites.net/";		#endregion		#region "MENU"		public const string HOME = "home";		public const string PULISTING = "pulisting";		public const string PURESULTS = "puresults";		public const string CREATENEW = "createnew";		public const string FAVINPUTS = "favinputs";		public const string FAVRESULTS = "favresults";		public const string REMOVEINPUT = "Remove an input";		public const string REMOVEVIEW = "Remove a View";		public const string FILTER = "filter";		public const string SORT = "sort";		#endregion		#region "Dropdown"		public const string CURRENCY = "Currency";		public const string SECTOR = "Sector";		public const string BUSINESS = "Business";		public const string COUNTRY = "Country";        public const string LOCATION = "Location";        public const string ECOSPACE = "Ecospace";        public const string WHITEFIELD = "Whitefield";        public const string FASHION_SHOW = "Fashion Show";        public const string DANCE = "Dance";        public const string SPECIAL_EVENTS = "Special Events";		public const string SAVEDCURRENCY = "SavedCurrency";		public const string SAVEDSECTOR = "SavedSector";		public const string SAVEDBUSINESS = "SavedBusiness";		public const string SAVEDCOUNTRY = "SavedCountry";		#endregion		#region "Messaging Center"		public const string SINGLE_SELECTION = "SINGLE_SELECTION";		public const string CONTEXTUAL_MENU = "CONTEXTUAL_MENU";		public const string MULTIPLE_SELECTION = "MULTIPLE_SELECTION";		public const string CHANGETAB = "CHANGETAB";		public const string CLEARCHANGETAB = "CLEARCHANGETAB";		public const string REJECTION_ITEM = "REJECTIONITEM";		public const string SUBMIT_ITEM = "SUBMITITEM";		#endregion		#region "Colors"		public const string WHITE = "#FFFFFF";		public const string RED = "#97040B";		public const string TEXT_GRAY = "#818181";		public const string BLACK = "#000000";		public const string BLUE = "#033462";		public const string GREEN = "#1F5D24";		public const string LIGHT_GRAY = "#DEDEDE";		public const string SUBMITDISABLED = "#95989A";					#endregion		#region "IMAGES"		public const string CONTEXTUAL_ICON = "moreMenu.png";		public const string HAMBURGER_ICON = "HamburgerIcon.png";		public const string BACK_ICON = "ic_arrow_back.png";		public const string DONE_ICON = "DONE.png";		public const string REFRESH_ICON = "ic_refresh.png";		#endregion		#region "Others"		public const string NEWLINE = "\n";		#endregion		#region "keys"		public const string SECTOR_SELECTION = "sectorselection";		public const string SAVED_INPUTS = "savedinputs";		public const string SAVED_RESULTS = "savedresults";		public const string UPDATE_INPUTS = "updateinputs";		public const string BU_ITEMS = "buitems";		public const string MY_FAVORITES = "My Favorites";		public const string SCANDIT = "Scandit Scanner";		public const string ZXING = "ZXing Scanner";		public const string FINANCIAL = "Financial";		public const string NONE = "None";		#endregion		#region "APP NAMES"		public const string TEKUtsavSCAN = "TEKUtsavScan";		#endregion		#region		public const string CONTAINER_CONDITION_CHECKLIST_API = "insertpodetails?ZUMO-API-VERSION=2.0.0";        public const string MEASUREMENTS_API = "insertmaterialmeasurements?ZUMO-API-VERSION=2.0.0";        public const string USER_API = "user?ZUMO-API-VERSION=2.0.0";        public const string EVENT_VOTE_API = "tables/eventvote? ZUMO-API-VERSION=2.0.0";        public const string COMPUTE_WINNER_API = "computeeventwinner?ZUMO-API-VERSION=2.0.0";        public const string EVENT_VOTING_SCHEDULE = "switchvotinglines?ZUMO-API-VERSION=2.0.0";        public const string EVENT_TYPE_API = "tables/eventtype?ZUMO-API-VERSION=2.0.0";        //&$expand=eventVotingSchedules		//public const string SUBMIT_PO_API = "http://localhost:59994/tables/purchaseorder/746EA6C7-2C4A-41F1-9F55-234285603745?ZUMO-API-VERSION=2.0.0"		#endregion		#region "UNITS"		public const string KILOGRAM = "KG.";		public const string POUNDS = "LBS.";		public const string FAHRENHEIT = "°F";		public const string CELCIUS = "°C";		public const string INCHES = "inches";		public const string FEET = "feet";		public const string METER = "m";		public const string CENTIMETER = "cm";		#endregion		#region		public const string PURCHASEORDERNUMBER = "PO# ";		public const string WAREHOUSE_USER = "warehouse";		public const string LOGISTICS_USER = "logistics";		public const string ITEM_ROWSTATUS = "active";        public const string US_CUSTOMARY = "US Customary";        public const string METRIC_SYSTEM = "Metric";        public const string INTERNATIONAL_UNITS = "International Units";		#endregion		#region "FLAGS"        public const bool DEBUGLOG = false;		#endregion		#region "API KEYS"		public const string CONTAINER_CONDITIONS = "ContainerConditions";		public const string ORDER = "Order";		public const string PURCHASE_ORDER = "PurchaseOrder";        public const string EVENT = "Event";        public const string EVENT_VOTE = "EventVote";        public const string CHECK_EVENT_VOTING = "EventVotingSchedule";        public const string EVENT_TYPE = "eventtype";        public const string EVENT_KEY = "EventType, EventType/EventVotingSchedules";        public const string EVENT_VOTE_KEY = "eventVotingSchedules";        public const string NOTIFICATION = "notification";        public const string CHECK_USER_VOTE = "checkuservote";		public const string PURCHASEORDER_SYNC = "syncpurchaseorders";		public const string PURCHASEORDERS_KEY = "PurchaseOrderMaterials, PurchaseOrderMaterials/PurchaseOrderMaterialStatus, PurchaseOrderStatus";		public const string DATE = "Date";		public const string COMPLETEDPURCHASEORDERS_KEY = "PurchaseOrderMaterials, PurchaseOrderMaterials/PurchaseOrderMaterialStatus, PurchaseOrderStatus";		public const string PURCHASEORDER_KEY = "PurchaseOrderMaterials,PurchaseOrderWorkflow/ContainerConditionComments,PurchaseOrderWorkflow/MaterialMeasurements, PurchaseOrderMaterials/PurchaseOrderMaterialStatus";		public const string CONTAINER_CHECKLIST = "PurchaseOrderMaterials,PurchaseOrderWorkflow/ContainerConditionStatuses/ContainerConditionChecklist,PurchaseOrderWorkflow/MaterialMeasurements";		#endregion		#region		public const string PNG = ".png";		public const string JPG = ".jpg";		public const string PDF = ".pdf";		public const string CSV = ".csv";		#endregion        #region "FIREBASE KEYS"        public const string FIREBASE_LISTENTING_STRING = "Endpoint=b://tekutsavnotificationns.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=TmddfKzRQ2hI+XiLvTEbVP+JOWJMVinmB8vh1ceftfg=";        public const string FIREBASE_NOTIFICATION_HUB_NAME = "tekutsavnotificationhub";        public const string FIREBASE_URL = "https://fcm.googleapis.com/fcm/send";        public const string FIREBASE_TOPIC_EVENT = "event";        public const string FIREBASE_SERVER_KEY = "AAAAWrjDD2I:APA91bFx1n04uoprRxVMonG575yYnTUbzKlzCDlxmWn8A_5MG98yimszeyvGeIQ_kyRTfQjiBgJTkMvyozaI_939gldMIXI62M5VSDFj8JCaHuTlD89w4JRXQNqrtGesvk-qZ3ULwCZL";        public const string FIREBASE_REQUEST_TYPE = "POSt";        #endregion	}}