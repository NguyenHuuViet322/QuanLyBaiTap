function newmaster_toggle() {
	var element = document.getElementById("reason_2");
	var member_change = document.getElementById("name_change");
	var input   = document.getElementById("new_master");

	if (element.value == "doi_chu_ho") {
		input.disabled = false;
		member_change.disabled = true;
	} else
	{
		if (member_change.value == document.getElementById("family_master").innerText) {
			member_change.disabled = false;
			input.disabled = false;
		} else
		{
			member_change.disabled = false;
			input.disabled = true;
		}
	}
}

function displayForm() {
	if (document.getElementById("search-form").style.display == "none") 
	{
		document.getElementById("search-form").style.display = "block";
		document.getElementById("search-form").style.opacity = 1;
	}
	else
	{
		document.getElementById("search-form").style.display = "none";
		document.getElementById("search-form").style.opacity = 0;
	}
}

function addMemberDisplay() {
	var element = document.getElementById("reason_1");

	if (element.value == "moi_sinh") 
	{
		document.getElementById("member_info_1").style.display = "none";
		document.getElementById("member_info_2").style.display = "block";
		document.getElementById("minfo1").removeAttribute("required");
		document.getElementById("minfo2").removeAttribute("required");
		document.getElementById("minfo3").removeAttribute("required");
		document.getElementById("minfo4").removeAttribute("required");
		document.getElementById("minfo5").removeAttribute("required");
		document.getElementById("minfo6").removeAttribute("required");
		document.getElementById("minfo7").removeAttribute("required");
	}	
	else {
		if (element.value == "moi_chuyen_toi") 
		{
			document.getElementById("member_info_1").style.display = "block";
			document.getElementById("member_info_2").style.display = "block";
			document.getElementById("minfo1").setAttribute("required","");
			document.getElementById("minfo2").setAttribute("required","");
			document.getElementById("minfo3").setAttribute("required","");
			document.getElementById("minfo4").setAttribute("required","");
			document.getElementById("minfo5").setAttribute("required","");
			document.getElementById("minfo6").setAttribute("required","");
			document.getElementById("minfo7").setAttribute("required","");
		}	
		else 
		{
			if (element.value == "none") 
			{
				document.getElementById("member_info_1").style.display = "none";
				document.getElementById("member_info_2").style.display = "none";
			}
		}
	}
	
}

function changeMemberDisplay() {
	var element = document.getElementById("reason_2");
	newmaster_toggle();

	if (element.value == "chuyen_di") 
	{
		document.getElementById("member_change").style.display = "block";
	}	
	else {
		if (element.value == "qua_doi") 
		{
			document.getElementById("member_change").style.display = "none";
		}	
		else 
		{
			if (element.value == "none") 
			{
				document.getElementById("member_change").style.display = "none";
			}
		}
	}
	
}
