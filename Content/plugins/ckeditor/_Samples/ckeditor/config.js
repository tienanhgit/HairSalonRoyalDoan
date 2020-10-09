﻿/*
Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';

	CKEDITOR.editorConfig = function (config) {

		config.language = 'en';
		config.filebrowserBrowseUrl = '/Content/ckfinder/ckfinder.html';
		config.filebrowserImageUrl = "/Content/ckfinder/ckfinder.html?type=Images";
		config.filebrowserFlashUrl = "/Content/ckfinder/ckfinder.html?type=Flash";
		config.filebrowserUploadUrl = '/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
		config.filebrowserImageUploadUrl = '/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
		config.filebrowserFlashUploadUrl = '/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
		// Define changes to default configuration here.
		// For complete reference see:
		// https://ckeditor.com/docs/ckeditor4/latest/api/CKEDITOR_config.html

		// The toolbar groups arrangement, optimized for two toolbar rows.
		config.toolbarGroups = [
			{ name: 'clipboard', groups: ['clipboard', 'undo'] },
			{ name: 'editing', groups: ['find', 'selection', 'spellchecker'] },
			{ name: 'links' },
			{ name: 'insert' },
			{ name: 'forms' },
			{ name: 'tools' },
			{ name: 'document', groups: ['mode', 'document', 'doctools'] },
			{ name: 'others' },
			'/',
			{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
			{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'] },
			{ name: 'styles' },
			{ name: 'colors' },
			{ name: 'about' }
		];

		// Remove some buttons provided by the standard plugins, which are
		// not needed in the Standard(s) toolbar.
		config.removeButtons = 'Underline,Subscript,Superscript';

		// Set the most common block elements.
		config.format_tags = 'p;h1;h2;h3;pre';

		// Simplify the dialog windows.
		config.removeDialogTabs = 'image:advanced;link:advanced';
	}

};
