import React, {useEffect, useState} from "react";
import * as actions from "../../actions/diary";
import { connect } from 'react-redux';

const Info = (props) => {

    useEffect(() => {
        props.fetchById(props.match.params.id)
    }, [])

    console.log(props.location.state.id)

    return(
        <div className="content">
            <div className="background">
                <div className="container">

                    <div className="diary__block">
                        <div className="diary__field1">
                            <div className="title1">
                                <p>TITLE</p>
                            </div>
                            <div className="textarea1">
                                <textarea className="title" defaultValue={props.location.state.title} readOnly={true}></textarea>
                            </div>
                        </div>
                        <div className="diary__field2">
                            <div className="title2">
                                <p>ENTRIES</p>
                            </div>
                            <div className="textarea2">
                                <textarea className="notes" defaultValue={props.location.state.entries} readOnly={true}></textarea>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

const mapStateToProps = state => ({
    diaryList: state.diary.list
})

const mapActionToProps = {
    fetchById: actions.fetchById
}

export default connect(mapStateToProps, mapActionToProps)(Info);