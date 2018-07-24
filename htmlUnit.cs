using com.gargoylesoftware.htmlunit;
using com.gargoylesoftware.htmlunit.html;
using org.apache.http.auth;

// web client
private WebClient webClient = new WebClient(BrowserVersion.INTERNET_EXPLORER_11);

public bool Setup()
{
    try
    {
        AuthScope authScope = new AuthScope(AuthScope.ANY_HOST, AuthScope.ANY_PORT, AuthScope.ANY_REALM, AuthScope.ANY_SCHEME);
        Credentials credentials = new NTCredentials(txtLogin.Text.Trim(), txtPassword.Text.Trim(), "worksation", "risorse");
        DefaultCredentialsProvider defaultCredentialsProvider = new DefaultCredentialsProvider();
        defaultCredentialsProvider.setCredentials(authScope, credentials);
        webClient.setCredentialsProvider(defaultCredentialsProvider);
        webClient.getOptions().setThrowExceptionOnFailingStatusCode(false);
        webClient.getOptions().setThrowExceptionOnScriptError(false);
        webClient.getOptions().setUseInsecureSSL(true);
        webClient.getOptions().setJavaScriptEnabled(true);
        webClient.getOptions().setRedirectEnabled(true);
        webClient.getOptions().setPrintContentOnFailingStatusCode(false);
        //webClient.setHTMLParserListener(HTMLParserListener.LOG_REPORTER);
        webClient.setRefreshHandler(new ImmediateRefreshHandler());
        webClient.setAjaxController(new NicelyResynchronizingAjaxController());
        webClient.setHTMLParserListener(null);
        webClient.setJavaScriptErrorListener(null);
        webClient.setJavaScriptTimeout(60000);
        webClient.waitForBackgroundJavaScript(60000);
        java.util.logging.Logger.getLogger("com.gargoylesoftware").setLevel(java.util.logging.Level.OFF);
        java.util.logging.Logger.getLogger("com.gargoylesoftware.htmlunit").setLevel(java.util.logging.Level.OFF);
        return true;
    }
    catch
    {
        return false;
    }
}
