import React from 'react'
import ReactDOM from 'react-dom/client'
import { Auth0Provider } from '@auth0/auth0-react'
import App from './App.tsx'
import './index.css'

ReactDOM.createRoot(document.getElementById('root')!).render(
  <Auth0Provider
    domain="dev-jeryzg1ji3bk2eex.us.auth0.com"
    clientId="EythnM0JPTmiA1H3fNx1iaWmxdvgJ3Ib"
    authorizationParams={{
      redirect_uri: window.location.origin
    }}
  >
    <React.StrictMode>
      <App />
    </React.StrictMode>,
  </Auth0Provider>,
)
