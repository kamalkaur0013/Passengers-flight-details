<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

  <xsl:template match="/">
    <html>
      <head>
        <title>Itineraries</title>
        <link rel="stylesheet" type="text/css" href="SiteStyles.css"/>
      </head>
      <body>
        <h1>
          Itneraries of <xsl:value-of select="count(/itineraries/itinerary/passenger)"/> passengers
        </h1>
        <h2>
          <xsl:for-each select="/itineraries/itinerary">
            <h2>
              Passenger: <xsl:value-of select="passenger"/>
            </h2>
            <table>
              <tr>
                <th></th>
                <th>Departure</th>
                <th>Arriving</th>
              </tr>
              <tr>
              </tr>
              <tr>
                <td>
                  Outbound
                </td>
                <td>
                  <xsl:value-of select="outbound/departure/city" />
                </td>
                <td>
                  <xsl:value-of select="outbound/arriving/city" />
                </td>
              </tr>
              <tr>
                <td>
                  Inbound
                </td>
                <td>
                  <xsl:value-of select="inbound/departure/city" />
                </td>
                <td>
                  <xsl:value-of select="inbound/arriving/city" />
                </td>
              </tr>
            </table>
          </xsl:for-each>
        </h2>
        
            
          
         
      </body>
    </html>
  </xsl:template>
  
  
  
</xsl:stylesheet>
