<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <body>
        <h2>Facturación de Libros</h2>
        <table>

          <xsl:for-each select="Facturas/Factura">

            <tr bgcolor="#1FC533">
              <th colspan="2">Factura</th>
            </tr>
            <tr>
              <td>Número:</td>
              <td>
                <xsl:value-of select="./@Numero"/>
              </td>
			</tr>
			<tr>  
              <td>Fecha:</td>
              <td>
                <xsl:value-of select="./@Fecha"/>
              </td>
			</tr>
			<tr>  
              <td>Total:</td>
              <td>
                <xsl:value-of select="./@Total"/>
              </td>
            </tr>

            <tr bgcolor="#fafad2">
              <th colspan="2">Cliente</th>
            </tr>
            <tr>
              <td>Nombre:</td>
              <td colspan="2">
                <xsl:value-of select="./Cliente/Nombre"/>
              </td>
            </tr>
            <tr>
              <td>Email:</td>
              <td colspan="2">
                <xsl:value-of select="./Cliente/Email"/>
              </td>
            </tr>
            <tr>
              <td>Teléfono</td>
              <td colspan="2">
                <xsl:value-of select="./Cliente/@Telefono"/>
              </td>
            </tr>

            <tr bgcolor="#fafad2">
              <th colspan="2">Libro</th>
            </tr>
            <tr>
              <td>Título:</td>
              <td>
                <xsl:value-of select="./Libro/@Titulo"/>
              </td>
            </tr>
            <tr>
              <td>Precio:</td>
              <td>
                <xsl:value-of select="./Libro/@Precio"/>
              </td>
            </tr>
            <tr>
              <td>Genero:</td>
              <td>
                <xsl:value-of select="./Libro/Genero"/>
              </td>
            </tr>
            <tr>
              <td>Editorial:</td>
              <td>
                <xsl:value-of select="./Libro/Editorial"/>
              </td>
            </tr>
            <tr>
              <td>Cantidad:</td>
              <td>
                <xsl:value-of select="./Libro/@Cantidad"/>
              </td>
            </tr>

            <tr bgcolor="#fafad2">
              <th colspan="2">Opcionales</th>
            </tr>
            <xsl:for-each select="./Opcionales/Opcional">
              <tr>
                <td colspan="2">
                  <xsl:value-of select="."/>
                </td>
              </tr>
            </xsl:for-each>

          </xsl:for-each>

        </table>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>