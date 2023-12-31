﻿using MVVMMaui.VM;
using ViewModel;

namespace MVVMMaui.Pages;

public partial class SkinPage : ContentPage
{
	public SkinPage(SkinVM skinVM)
	{
		InitializeComponent();
		BindingContext = new PageSkinVM(skinVM);
	}
}
