﻿/*!@license
* Infragistics.Web.ClientUI Dialog localization resources 16.2.20162.2141
*
* Copyright (c) 2011-2017 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

(function (factory) {
	if (typeof define === "function" && define.amd) {
		define( [
			"jquery"
		], factory );
	} else {
		factory(jQuery);
	}
}
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Dialog) {
	    $.ig.Dialog = {
		    locale: {
			    closeButtonTitle: "閉じる",
			    minimizeButtonTitle: "最小化",
			    maximizeButtonTitle: "最大化",
			    pinButtonTitle: "ピン固定",
			    unpinButtonTitle: "ピン固定の解除",
			    restoreButtonTitle: "元に戻す",
				setOptionError: '次のオプションはランタイムで変更できません: '
		    }
	    };
    }
}));// REMOVE_FROM_COMBINED_FILES
