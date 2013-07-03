$(function(){
    var $name=$('.name');
    var $docTypeDivs=$('.docType');
    var $docTypeBox=$(".docTypeID");
    
    //console.log($docTypeBox);
    
    $(".docType").click(function(){
        var $thisDocType=$(this);
        
        //clear all other classes
        $(".docType").removeClass("selected");
        
        $thisDocType.addClass("selected");
        $docTypeBox.val($thisDocType.attr('rel'));
    });
    
    //ini
    //if only one doc type, select it
    if($docTypeDivs.length==1){
        $($docTypeDivs[0]).click();
    }
    
    $(".createButton").click(function(){
        var $button=$(this);

        //console.log($docTypeBox.val());
        
        if($docTypeBox.val()!=''&&$name.val()!=''){
            $button.closest("form").submit();
        }
    });   
});