<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:sa="http://www.w3schools.com">
  <xsl:template match="/">
    <center>
      <h1>
        Customer Orders 
      </h1>
      <xsl:for-each select="//sa:Product">
        <br /><b>
          <big>
            <big>
              <xsl:value-of select="@ProductName"/>
            </big>
          </big>
        </b>
        (Size: <xsl:value-of select="@Size"/> )
        <table>
          <tr>
            <th>Customer ID</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>City</th>
            <th>State</th>
          </tr>
          <xsl:for-each select="sa:Customer">
            <tr>
              <td align="center">
                <xsl:value-of select="@CustomerID"/>
              </td>
              <td align="center">
                <xsl:value-of select="@Fname"/>
              </td>
              <td align="center">
                <xsl:value-of select="@Lname"/>
              </td>
              <td align="center">
                <xsl:value-of select="@City"/>
              </td>
              <td align="center">
                <xsl:value-of select="@State"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </xsl:for-each>
    </center>

  </xsl:template>
</xsl:stylesheet>
