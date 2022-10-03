(async () => {
    console.log("TEST");
	const response = await fetch("/get-all-quizes");	
    console.log("response", response);
})();