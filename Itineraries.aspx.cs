using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml.Serialization;


public partial class Itineraries : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string xmlFile = MapPath(@"~/App_Data/itineraries.xml");
		lblConfirmation.Visible = false;

        if (!IsPostBack)
        {
            //Use the names of the restaurants in the XML file  to populate the dropdown list

           
            FileStream xs = new FileStream(xmlFile, FileMode.Open);
            XmlSerializer serializor = new XmlSerializer(typeof(itineraries));

            itineraries ItinerariesInfo = (itineraries)serializor.Deserialize(xs);
            int index = 1; // index number of resturants.

            ListItem itinerariesList = new ListItem("--select one--", String.Empty);

            drpPassenger.Items.Insert(0, itinerariesList);

            foreach (itinerariesItinerary name in ItinerariesInfo.itinerary)
            {
                drpPassenger.Items.Insert(index, name.passenger);
                index = index + 1;
            }
            xs.Close();

        }
    }

    protected void drpPassenger_SelectedIndexChanged(object sender, EventArgs e)
    {
        string xmlFile = MapPath(@"~/App_Data/itineraries.xml");

        FileStream xs = new FileStream(xmlFile, FileMode.Open);
        XmlSerializer serializor = new XmlSerializer(typeof(itineraries));

        itineraries ItinerariesInfo = (itineraries)serializor.Deserialize(xs);


        string itinerarySelected = drpPassenger.SelectedValue;



        foreach (itinerariesItinerary name in ItinerariesInfo.itinerary)
        {
            if (itinerarySelected == name.passenger)
            {


                txtOutboundDeparture.Text = name.outbound.departure.city;
                txtOutboundArriving.Text = name.outbound.arriving.city;
                txtInboundDeparture.Text = name.inbound.departure.city;
                txtInboundArriving.Text = name.inbound.arriving.city;

                Session["OutboundDeparture"] = txtOutboundDeparture.Text.ToString();

                Session["OutboundArriving"] = txtOutboundArriving.Text.ToString(); 
                Session["InboundDeparture"] = txtInboundDeparture.Text.ToString();

                Session["InboundArriving"] = txtInboundArriving.Text.ToString();

            }
            xs.Close();
        }
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string xmlFile = MapPath(@"~/App_Data/itineraries.xml");

        FileStream xs = new FileStream(xmlFile, FileMode.Open);
        XmlSerializer serializor = new XmlSerializer(typeof(itineraries));

        itineraries ItinerariesInfoupdated = (itineraries)serializor.Deserialize(xs);

        xs.Close();

        string OutboundDepartureSession = Session["OutboundDeparture"].ToString();

        string OutboundArrivingSession = txtOutboundArriving.Text.ToString();

        string InboundDepartureSession = txtInboundDeparture.Text.ToString();


        string InboundArrivingSession = txtInboundArriving.Text.ToString();
        string itinerarySelected = drpPassenger.SelectedValue;

        // save the updated information to ResturantInfoUpdate. 
        foreach (itinerariesItinerary name in ItinerariesInfoupdated.passenger)
        {
            if (itinerarySelected == name.passenger)
            {
                //if the txt summary is not equal to the saved summary session than we will update the xml file 
                if (txtOutboundDeparture.Text != OutboundArrivingSession)
                {
                    name.outbound.departure.city = txtOutboundDeparture.Text.ToString();


                    


                    FileStream updated_xs = new FileStream(xmlFile, FileMode.Create); // create is for update 
                    XmlSerializer serializor_update = new XmlSerializer(typeof(itineraries));
                    serializor_update.Serialize(updated_xs, ItinerariesInfoupdated);

                    updated_xs.Close();

                   

                }

                if (txtOutboundArriving.Text != OutboundArrivingSession)
                {
                    name.outbound.arriving.city = txtOutboundArriving.Text.ToString();





                    FileStream updated_xs = new FileStream(xmlFile, FileMode.Create); // create is for update 
                    XmlSerializer serializor_update = new XmlSerializer(typeof(itineraries));
                    serializor_update.Serialize(updated_xs, ItinerariesInfoupdated);

                    updated_xs.Close();



                }
                if (txtInboundArriving.Text != InboundArrivingSession)
                {
                    name.outbound.arriving.city = txtInboundArriving.Text.ToString();





                    FileStream updated_xs = new FileStream(xmlFile, FileMode.Create); // create is for update 
                    XmlSerializer serializor_update = new XmlSerializer(typeof(itineraries));
                    serializor_update.Serialize(updated_xs, ItinerariesInfoupdated);

                    updated_xs.Close();



                }

                if (txtOutboundArriving.Text != InboundDepartureSession)
                {
                    name.outbound.departure.city = txtInboundDeparture.Text.ToString();





                    FileStream updated_xs = new FileStream(xmlFile, FileMode.Create); // create is for update 
                    XmlSerializer serializor_update = new XmlSerializer(typeof(itineraries));
                    serializor_update.Serialize(updated_xs, ItinerariesInfoupdated);

                    updated_xs.Close();



                }
                lblConfirmation.Visible = true;
        lblConfirmation.Text = "Revised Itinerary has been saved to <br/>" + xmlFile;
    }    
}