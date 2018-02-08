  
            $(function () {
                $(".datepicker").datepicker({
                    dateFormat: "dd MM yy",
                    minDate: 0,
                    beforeShowDay: $.datepicker.noWeekends
                });
            }
        );
