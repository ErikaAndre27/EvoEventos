import React from 'react'
import './MainHome.css'
import CustomHeader from './components/customHeader'
import HeroSection from './components/HeroSection'
import CustomFooter from './components/CustomFooter'
import CustomMain from './components/CustomMain'


const MainHome = () => {
    return (
        <>
            {/* // HEADER */}
            <CustomHeader />
            {/* MAIN */}
            <HeroSection />
            <CustomMain />

            {/* FOOTER */}
            <CustomFooter />

        </>
    )
}

export default MainHome
