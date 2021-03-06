import React from "react"
import PropTypes from "prop-types"
import { HashRouter, Route, Link } from 'react-router-dom'
import {History} from "core/components/history"

export default class BaseLayout extends React.Component {
  static propTypes = {
    errSelectors: PropTypes.object.isRequired,
    errActions: PropTypes.object.isRequired,
    specActions: PropTypes.object.isRequired,
    specSelectors: PropTypes.object.isRequired,
    layoutSelectors: PropTypes.object.isRequired,
    layoutActions: PropTypes.object.isRequired,
    getComponent: PropTypes.func.isRequired
  }

  constructor(props) {
    super(props);
    this.state = { showSidebar: true, leftPadding: '250px' };
  }

  onFilterChange = (e) => {
    let { target: { value } } = e
    this.props.layoutActions.updateFilter(value)
  }

  toggleSidebar = () => {
    this.state.showSidebar= !this.state.showSidebar//we have to set this before we call setState because its not changing it in local scope
    this.setState({ showSidebar: this.state.showSidebar });

    if (this.state.showSidebar === true) {
           this.setState({ leftPadding: '250px' });
    } else { 
        this.setState({ leftPadding: '0px' });  
    }
  }

  render() {
    let { specSelectors, specActions, getComponent, layoutSelectors } = this.props
    let taggedOps = specSelectors.taggedOperations()
    let info = specSelectors.info()
    let url = specSelectors.url()
    let basePath = specSelectors.basePath()
    let host = specSelectors.host()
    let externalDocs = specSelectors.externalDocs()
    let schemes = specSelectors.schemes()
    let Info = getComponent("info")
    let Operations = getComponent("operations", true)
    let Operation = getComponent("operation", true)
    let Sidebar = getComponent("sidebar", true)
    let Models = getComponent("Models", true)
    let Row = getComponent("Row")
    let Col = getComponent("Col")
    let Errors = getComponent("errors", true)
    const Header = getComponent("header", true)
    let isLoading = specSelectors.loadingStatus() === "loading"
    let isFailed = specSelectors.loadingStatus() === "failed"
    let filter = layoutSelectors.currentFilter()
    let inputStyle = {}
    if (isFailed) inputStyle.color = "red"
    if (isLoading) inputStyle.color = "#aaa"
    const Schemes = getComponent("schemes")
    const isSpecEmpty = !specSelectors.specStr()

    if (isSpecEmpty) {
      return <h4>No spec provided.</h4>
    }

    var baseUrl = window.swashbuckleConfig.baseUrl

    return (
      <span>
      <Sidebar taggedOps={taggedOps} toggleSidebarFunc={this.toggleSidebar} showSidebar={this.state.showSidebar} />
      <div className='swagger-ui'>               
                <div id="swagger-ui-container" style={{ paddingLeft: this.state.leftPadding }}>
                <Header />
                <Errors />
                      <HashRouter basename={ baseUrl } hashType="noslash">
                       <span>
                          <Route path={"/"} exact key={"home"} render={x => 
                                <Row className="information-container">
                                            <Col mobile={12}>
                                                {info.count() ? (
                                                    <Info info={info} url={url} host={host} basePath={basePath} externalDocs={externalDocs} getComponent={getComponent} />
                                                ) : null}
                                            </Col>
                                        </Row>
                                } />      
                          <Route path={"/history"} exact key={"history"}  render={x=> <History specSelectors={specSelectors} /> } />                 
                         </span>
                         </HashRouter>

                    {
                        filter === null || filter === false ? null :
                            <div className="filter-container">
                                <Col className="filter wrapper" mobile={12}>
                                    <input className="operation-filter-input" placeholder="Filter by tag" type="text" onChange={this.onFilterChange} value={filter === true || filter === "true" ? "" : filter} disabled={isLoading} style={inputStyle} />
                                </Col>
                            </div>
                    }

                    <Row>
                        <Col mobile={12} desktop={12} >
                            <Operations />
                        </Col>
                    </Row>
                    { /* <Row>
                         <Col mobile={12} desktop={12} >
                             <Models />
                         </Col>
                    </Row> */}
                </div>
            </div>
            </span>

    )
  }
}
