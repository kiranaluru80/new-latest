using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ReadDataFromJson
{
	public class ReadDataViewModel : ViewModelBase
	{
        private Xamarin.Forms.Command _enableExec;
		public List<SearchOrgUsersResult> OrgRelatedData => orgRelatedData;

		List<SearchOrgUsersResult> orgRelatedData = new List<SearchOrgUsersResult>();
		List<SearchOrgUsersResult> SroringData = new List<SearchOrgUsersResult>();
		public Command EnableExec => _enableExec ?? (_enableExec = new Command(ExecuteCommand));
        private void ExecuteCommand()
        {
            PopOverVisible = true;
        }


		//Picker related Data start
		public class PickerData
		{
			public string Name { get; set; }
			public string Id { get; set; }
		}

		public List<PickerData> RootObjectSe => rootObjectSe;
		List<PickerData> rootObjectSe = new List<PickerData>();

		SearchOrgUsersResult _listSelectedItem;
		public SearchOrgUsersResult ListSelectedItem
		{
			get { return _listSelectedItem; }
			set
			{
				if (_listSelectedItem != value)
				{
					_listSelectedItem = value;
                    EntryText = _listSelectedItem.FirstName;
                    SearchText = _listSelectedItem.FirstName;
                   PopOverVisible = false;//button action
					OnPropertyChanged("ListSelectedItem");
				}
			}
		}
		//Picker related data end

        bool _popOverVisible;
        public bool PopOverVisible
		{
			get { return _popOverVisible; }
			set
			{
				if (_popOverVisible != value)
				{
					_popOverVisible = value;
					OnPropertyChanged("PopOverVisible");
				}
			}
		}

		string _entryText;
        public string EntryText
		{
			get { return _entryText; }
			set
			{
				if (_entryText != value)
				{
					_entryText = value;
					OnPropertyChanged("EntryText");
				}
			}
		}


		string _searchText;
		public string SearchText
		{
			get { return _searchText; }
			set
			{
				if (_searchText != value)
				{
					_searchText = value;
					OnPropertyChanged("SearchText");
				}
			}
		}

		PickerData selectedMajorGroup;
		public PickerData SelectedMajorGroup
		{
			get { return selectedMajorGroup; }
			set
			{
				if (selectedMajorGroup != value)
				{
					selectedMajorGroup = value;
					OnPropertyChanged();
					OnPropertyChanged("SelectedMajorGroup");
				}
			}
		}

		public void textChangedMethod(string searchBarText)
		{
			//orgRelatedData = orgRelatedData.OrderBy(x => x.FirstName).ToList();
			if (searchBarText == null || searchBarText == "")
			{
				Debug.WriteLine("Cancel Pressed");
				orgRelatedData = SroringData;
			}

			else if (searchBarText.Length > 0)
			{
				orgRelatedData = SroringData.Where(x => x.FirstName.Contains(searchBarText)).ToList();
			}

			OnPropertyChanged("OrgRelatedData");
		}


		public ReadDataViewModel()
		{
			var assembly = typeof(ReadDataViewModel).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("ReadDataFromJson.getbannerdata.json");


			PickerData obj = new PickerData();
			obj.Name = "Bharath";
			obj.Id = "702";

			PickerData objTwo = new PickerData();
			objTwo.Name = "subbu";
			objTwo.Id = "802";

			rootObjectSe.Add(obj);
			rootObjectSe.Add(objTwo);



			using (var reader = new System.IO.StreamReader(stream))
			{

				var json = reader.ReadToEnd();
				RootObjectNew data = JsonConvert.DeserializeObject<RootObjectNew>(json);

				for (int i = 0; i < data.SearchOrgUsersResult.Count; i++)
				{
					SearchOrgUsersResult dataObject = data.SearchOrgUsersResult[i];
					Debug.WriteLine("First Major ID :" + i + "= " + dataObject.FirstName);
					Debug.WriteLine("First Major Name :" + i + "= " + dataObject.LastName);
					orgRelatedData.Add(dataObject);
				}
				SroringData = orgRelatedData;
			}



		}


	}
}
