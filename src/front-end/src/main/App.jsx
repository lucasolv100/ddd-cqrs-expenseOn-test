import '../../node_modules/bootstrap/dist/css/bootstrap.min.css'
import '../../node_modules/font-awesome/css/font-awesome.min.css'
import React from 'react'
import Menu from '../template/menu'
import Routes from './Routes'
import '../template/custom.css'

export default props => (
    <div className="container">
        <Menu />
        <Routes />
    </div>
)