import React from 'react'
import {HashRouter,Route,Link} from 'react-router-dom'
import {Redirect} from 'react-router'

import Hotel from '../hotel/Hotel'
import About from '../about/about'
import HotelFormRegister from '../hotel/HotelFormRegister'

export default props => (
    // <Router history={hashHistory}>
    //     <Route path='/hotels' component={Hotel} />
    //     <Route path='/about' component={About} />
    //     <Route path='/create' component={About} />
    //     <Redirect from='*' to='/hotels' />
    // </Router>
    <HashRouter>
      <div>
      <Route path='/hoteis' component={Hotel} />
         <Route path='/sobre' component={About} />
         <Route path='/criar-hotel' component={HotelFormRegister} />
         <Redirect from='*' to='/hoteis' />
      </div>
   </HashRouter >
)