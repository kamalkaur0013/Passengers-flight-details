<?php
    session_start();
    define("ITINERARY_PATH",     "Data/itineraries.xml");
    $itineraries = simplexml_load_file(ITINERARY_PATH);
    
    extract($_POST);
    $confirmation = false;
    
    if (isset($btnSave))
    {	
        foreach ($itineraries as $itinerariesinfo) {
        if ($itinerariesinfo->passenger == $drpPassenger) {
            $itinerariesinfo->outbound->departure->city=$txtOutboundDeparture;
            $itinerariesinfo->outbound->arriving->city =$txtOutboundArriving;
            $itinerariesinfo->inbound->departure->city=$txtInboundDeparture ;
            $itinerariesinfo->inbound->arriving->city = $txtInboundArriving;
            
            
            $itineraries->asXML('Data/itineraries.xml'); //save xml  
             $confirmation = "Revised itinerary has been saved to: " . ITINERARY_PATH;
           
        }
    }

       
    }

    
    
    include "./Common/Header.php";
?>
<div class="container"> 
     <div class="row vertical-margin">
        <div class="col-md-10 text-center"><h1>Itineraries</h1></div>
    </div>
    <form action="Itineraries.php" method="post" id="itineraries-form">
        <div class="row vertical-margin">
            <div class="col-md-2"><label for="drpPassenger">Passenger:</label></div>
            <div class="col-md-6">
                <select name="drpPassenger"  id= "drpPassenger" class="form-control" onchange="onPassengerChanged();">
                    <?php 
                       
                        //Add your code here to populate the dropdown list using passengers' name
                        foreach ($itineraries->itinerary as $itinerariesInfo)
                        { ?>
                         <option value="<?php echo $itinerariesInfo->passenger ?>" <?php echo (isset($_POST['drpPassenger']) && $_POST['drpPassenger'] == $itinerariesInfo->passenger) ? 'selected="selected"' : ''; ?>><?php echo $itinerariesInfo->passenger; ?>
                        </option>
                      <?php  
                      
                        }
                    ?>
					  
                    
                </select>
            </div>
        </div>
       
         <?php
            foreach ($itineraries->itinerary as $itinerariesInfo) {
                if ($itinerariesInfo->passenger == $drpPassenger) {
                    $txtOutboundDeparture = $itinerariesInfo->outbound->departure->city;
                    $txtOutboundArriving = $itinerariesInfo->outbound->arriving->city;
                    $txtInboundDeparture = $itinerariesInfo->inbound->departure->city;
                    $txtInboundArriving = $itinerariesInfo->inbound->arriving->city;
                    
                  
                }
            }
            ?>
             
        <div class="row vertical-margin">
           <div class="col-md-6 col-md-offset-2"><h3>Outbound</h3></div>
        </div>
        <div class="row vertical-margin">
            <div class="col-md-2"><label>Departure City:</label></div>
            <div class="col-md-6">
                <input type="text" class="form-control" rows="2" style="width : 100%" name="txtOutboundDeparture" value="<?php print $txtOutboundDeparture ?>"/>
            </div>
        </div>
        <div class="row vertical-margin">
            <div class="col-md-2"><label>Arriving City:</label></div>
            <div class="col-md-6">
                <input type="text" class="form-control" rows="2" style="width : 100%" name="txtOutboundArriving" value="<?php print $txtOutboundArriving ?>"/>
            </div>
        </div>
        <div class="row vertical-margin">
           <div class="col-md-6 col-md-offset-2"><h3>Inbound</h3></div>
        </div>
        <div class="row vertical-margin">
            <div class="col-md-2"><label>Departure City:</label></div>
            <div class="col-md-6">
                <input type="text" class="form-control" rows="2" style="width : 100%" name="txtInboundDeparture" value="<?php print $txtInboundDeparture ?>"/>
            </div>
        </div>
        <div class="row vertical-margin">
            <div class="col-md-2"><label>Arriving City:</label></div>
            <div class="col-md-6">
                <input type="text" class="form-control" rows="2" style="width : 100%" name="txtInboundArriving" value="<?php print $txtInboundArriving ?>"/>
            </div>
        </div>

        <div class="row vertical-margin">
            <div class="col-md-10 col-md-offset-2">
                <input type='submit'  class="btn btn-primary btn-min-width" name='btnSave' value='Save Changes'/>
            </div>
        </div>
        <div class="row" style="display: <?php print ($confirmation ?  'block' :'none' )?>" >
            <div class="col-md-8"><Label ID="lblConfirmation" class="form-control alert-success">
                <?php print $confirmation ?></Label>
            </div>
        </div>
    </form>
</div>
<br/>
<?php include "./Common/Footer.php"; ?>