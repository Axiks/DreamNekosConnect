import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'


ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
        <div className="flex justify-center">
          <App />
        </div>

        <script
            type="text/javascript"
            src="../node_modules/tw-elements/dist/js/tw-elements.umd.min.js"></script>
  </React.StrictMode>,
)