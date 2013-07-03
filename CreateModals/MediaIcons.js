$(function(){
    var $name=$('.name');
    var $mediaTypeDivs=$('.mediaType');
    var $mediaTypeBox=$(".mediaTypeID");
    
    //console.log($mediaTypeBox);
    
    $(".mediaType").click(function(){
        var $thismediaType=$(this);
        
        //clear all other classes
        $(".mediaType").removeClass("selected");
        
        $thismediaType.addClass("selected");
        $mediaTypeBox.val($thismediaType.attr('rel'));
    });
    
    //ini
    //if only one doc type, select it
    if($mediaTypeDivs.length==1){
        $($mediaTypeDivs[0]).click();
    }
    
    $(".createButton").click(function(){
        var $button=$(this);

        //console.log($mediaTypeBox.val());
        
        if($mediaTypeBox.val()!=''&&$name.val()!=''){
            $button.closest("form").submit();
        }
    });   
});