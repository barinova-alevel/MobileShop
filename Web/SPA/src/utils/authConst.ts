export const AuthConst = {
  authority: process.env.REACT_APP_AUTH_URL,
  client_id: process.env.REACT_APP_IDENTITY_CLIENT_ID,
  client_secret: process.env.REACT_APP_IDENTITY_CLIENT_SECRET,
  redirect_uri: process.env.REACT_APP_REDIRECT_URL,
  silent_redirect_uri: process.env.REACT_APP_SILENT_REDIRECT_URL,
  post_logout_redirect_uri: process.env.REACT_APP_LOGOFF_REDIRECT_URL,
  response_type: 'code',
  scope: 'openid profile mvc',
}