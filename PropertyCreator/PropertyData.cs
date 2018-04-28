using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PropertyCreator
	{
	public class PropertyData : CNotifier
		{
		private String _PropertyType = String.Empty;
		private String _PropertyInit = String.Empty;
		private String _PropertyName = String.Empty;
		private String _PropertyCode = String.Empty;

		public String PropertyType
			{
			get { return _PropertyType; }
			set
				{
				_PropertyType = value;
				OnPropertyChanged("PropertyType");
				}
			}

		public String PropertyInit
			{
			get { return _PropertyInit; }
			set
				{
				_PropertyInit = value;
				OnPropertyChanged("PropertyInit");
				}
			}

		public String PropertyName
			{
			get { return _PropertyName; }
			set
				{
				_PropertyName = value;
				OnPropertyChanged("PropertyName");
				}
			}

		public String PropertyCode
			{
			get { return _PropertyCode; }
			set
				{
				_PropertyCode = value;
				OnPropertyChanged("PropertyCode");
				}
			}

		private Boolean _IsDependencyProperty = false;
		public Boolean IsDependencyProperty
			{
			get { return _IsDependencyProperty; }
			set
				{
				_IsDependencyProperty = value;
				OnPropertyChanged("IsDependencyProperty");
				}
			}

		private String _ControlClassName;
		public String ControlClassName
			{
			get { return _ControlClassName; }
			set
				{
				_ControlClassName = value;
				OnPropertyChanged("ControlClassName");
				}
			}



		/*
		Example of generated code:
				public FileDialogTypeEnum FileDialogType
					{
					get { return (FileDialogTypeEnum)GetValue(FileDialogTypeProperty); }
					set { SetValue(FileDialogTypeProperty, value); }
					}

				public static readonly DependencyProperty FileDialogTypeProperty =
						DependencyProperty.Register("FileDialogType", typeof(FileDialogTypeEnum), typeof(FileInputBox), new PropertyMetadata(FileDialogTypeEnum.OpenFile));

		*/

		public void CreateDependencyProperty()
			{
			if (PropertyType.Length > 0 && PropertyName.Length > 0)
				{
				// Declare the property
				PropertyCode += "public " + PropertyType + " " + PropertyName + "\r\n";
				PropertyCode += "\t{\r\n";
				PropertyCode += "\tget { return (" + PropertyType + ") GetValue(" + PropertyName + "Property); }\r\n";
				PropertyCode += "\tset { SetValue(" + PropertyName + "Property, value); }\r\n";
				PropertyCode += "\t}\r\n\r\n";
				// Register the property
				PropertyCode += "public static readonly DependencyProperty " + PropertyName + "Property =\r\n";
				PropertyCode += "\tDependencyProperty.Register(\"" + PropertyName + "\", typeof(" + PropertyType + ")";
				if (ControlClassName.Length > 0)
					{
					PropertyCode += ", typeof(" + ControlClassName + ")";
					}
				if (PropertyInit.Length > 0)
					{
					PropertyCode += ", new PropertyMetaData(" + PropertyInit + "));\r\n";
					}
				else
					{
					PropertyCode += ");\r\n";
					}
				// Update clipboard
				Clipboard.SetText(PropertyCode);
				}
			}

		public void CreateProperty()
			{
			if (PropertyType.Length > 0 && PropertyName.Length > 0)
				{
				if (PropertyInit.Length == 0)
					{
					PropertyCode += "private " + PropertyType + " _" + PropertyName + ";\r\n";
					}
				else
					{
					PropertyCode += "private " + PropertyType + " _" + PropertyName + " = " + PropertyInit + ";\r\n";
					}
				PropertyCode += "public " + PropertyType + " " + PropertyName + "\r\n";
				PropertyCode += "\t{\r\n\t\tget { return _" + PropertyName + "; }\r\n";
				PropertyCode += "\t\tset { _" + PropertyName + "= value;\r\n";
				PropertyCode += "\t\t\tOnPropertyChanged(\"" + PropertyName + "\");}\r\n\t}\r\n";
				Clipboard.SetText(PropertyCode);
				}
			}

		public void AddProperty()
			{
			PropertyName = String.Empty;
			PropertyCode += "\r\n";
			}

		public void ClearAndAddProperty()
			{
			PropertyType = String.Empty;
			PropertyInit = String.Empty;
			PropertyName = String.Empty;
			PropertyCode += "\r\n";
			}

		public void Clear()
			{
			PropertyType = String.Empty;
			PropertyInit = String.Empty;
			PropertyName = String.Empty;
			PropertyCode = String.Empty;
			ControlClassName = String.Empty;
			IsDependencyProperty = false;
			}
		}
	}
