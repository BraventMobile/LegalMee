using System;
using RockMvvmForms;
using LegalMee.Services;
using Xamarin.Forms;
using System.Threading.Tasks;
using LegalMee.Models;
using LegalMee.Helpers;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;

namespace LegalMee
{
	public class FaqsViewModel: ViewModelBase
	{
		private readonly IFaqsService _faqsService;
		private ContenidoResult _contenidoRes;

		#region Constructor
		public FaqsViewModel ()
		{
			_faqsService = RockServiceLocator.Current.Get<IFaqsService> ();
		}
		#endregion

		public override async Task InitAsync()
		{

			try
			{

				IsBusy = true;

				_contenidoRes = await _faqsService.GetFrequentQuestion(new Cliente(){ ID = "113979102"}, new Colectivo() { Code = Settings.AppUserPlatform });

				if (_contenidoRes != null)
				{
					foreach(var cont in _contenidoRes.Contenidos)
					{
						SubMateria submatter = _contenidoRes.SubMaterias.FirstOrDefault(s => s.SubmateriaId == cont.SubMateriaId);
						cont.SubMatter = submatter.Nombre;

						int matterId = _contenidoRes.SubMaterias.Where(m => m.SubmateriaId == cont.SubMateriaId).Select(m => m.MateriaId).FirstOrDefault();
						cont.Matter = _contenidoRes.Materias.Where(m => m.MateriaId == matterId).Select(m => m.Nombre).FirstOrDefault();
					}

					QuestionsList = _contenidoRes.Contenidos;
					MateriasList = _contenidoRes.Materias.GroupBy(x => x.MateriaId).Select(x => x.First()).ToList();

				}
				IsBusy = false;

			}
			catch (Exception ex)
			{

				IsBusy = false;
				await Navigation.DisplayAlert("Error", ex.Message, "Ok");

			}

		}

		#region Properties


		#region QuestionList
		private List<Contenido> _QuestionsList = new List<Contenido>();
		public List<Contenido> QuestionsList
		{
			get
			{
				return _QuestionsList;
			}
			set
			{
				_QuestionsList = value;
				QuestionListCount = _QuestionsList.Count.ToString();
				OnPropertyChanged("QuestionsList");
			}
		}
		#endregion

		#region QuestionListCount
		private string _QuestionListCount;
		public string QuestionListCount
		{
			get
			{
				return _QuestionListCount;
			}
			set
			{
				_QuestionListCount = value;
				OnPropertyChanged("QuestionListCount");
			}
		}
		#endregion

		#region QuestionSearched
		private string _QuestionSearched;
		public string QuestionSearched
		{
			get
			{
				return _QuestionSearched;
			}
			set
			{
				_QuestionSearched = value;
				if (_contenidoRes != null) 
				{
					var res = _contenidoRes.Contenidos.Where (q => q.Title.ToUpper ().Contains (_QuestionSearched.ToUpper ())
						|| q.Matter.ToUpper ().Contains (_QuestionSearched.ToUpper ()) || q.SubMatter.ToUpper ().Contains (_QuestionSearched.ToUpper ())).ToList ();
					QuestionListCount = res.Count ().ToString ();
					QuestionsList = new List<Contenido> (res);
				}
				OnPropertyChanged("QuestionSearched");
			}
		}
		#endregion

		#region IsSearcherVisible
		private bool _IsSearcherVisible = true;
		public bool IsSearcherVisible
		{
			get
			{
				return _IsSearcherVisible;
			}
			set
			{
				_IsSearcherVisible = value;
				OnPropertyChanged("IsSearcherVisible");

			}
		}
		#endregion

		#region IsMatterFiltersVisible
		private bool _IsMatterFiltersVisible = false;
		public bool IsMatterFiltersVisible
		{
			get
			{
				return _IsMatterFiltersVisible;
			}
			set
			{
				_IsMatterFiltersVisible = value;
				OnPropertyChanged("IsMatterFiltersVisible");

			}
		}
		#endregion

		#region WordSearchImage
		private string _WordSearchImage;
		public string WordSearchImage
		{
			get
			{
				return _WordSearchImage;
			}
			set
			{
				_WordSearchImage = value;
				OnPropertyChanged("WordSearchImage");
			}
		}
		#endregion

		#region MatterSearchImage
		private string _MatterSearchImage;
		public string MatterSearchImage
		{
			get
			{
				return _MatterSearchImage;
			}
			set
			{
				_MatterSearchImage = value;
				OnPropertyChanged("MatterSearchImage");
			}
		}
		#endregion

		#region MateriasList
		private List<Materia> _MateriasList = new List<Materia>();
		public List<Materia> MateriasList
		{
			get
			{
				return _MateriasList;
			}
			set
			{
				_MateriasList = value;
				OnPropertyChanged("MateriasList");
			}
		}
		#endregion

		#region SubMaterias
		private List<SubMateria> _SubMaterias = new List<SubMateria>();
		public List<SubMateria> SubMaterias
		{
			get
			{
				return _SubMaterias;
			}
			set
			{
				_SubMaterias = value;
				OnPropertyChanged("SubMaterias");
			}
		}
		#endregion


		#endregion

		#region Commands



		#endregion

		#region Private voids


		#endregion
	}
}

