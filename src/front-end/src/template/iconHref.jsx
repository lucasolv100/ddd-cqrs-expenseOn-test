import React from 'react'
import If from './If'
import '../template/custom.css'

export default props => (
    <If test={!props.hide}>
        <a className={'custom-btn btn btn-' + props.style} href={props.onClick}>
            <i className={'fa fa-' + props.icon}></i>
        </a>
    </If>
)