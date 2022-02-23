export const AuthConst = {
  authority: process.env.REACT_APP_AUTH_URL,
  client_id: process.env.REACT_APP_IDENTITY_CLIENT_ID,
  client_secret: process.env.REACT_APP_IDENTITY_CLIENT_SECRET,
  response_type: 'code',
  scope: 'openid profile spa',
}