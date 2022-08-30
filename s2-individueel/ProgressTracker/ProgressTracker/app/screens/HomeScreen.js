import React from 'react';
import {ImageBackground, Text, SafeAreaView, TouchableHighlight, View} from 'react-native';
import {StatusBar} from "expo-status-bar";
import styles from "../styles/Main.styles"

function HomeScreen({ navigation }) {
    
    const pressHandlerRegister = () => {
        navigation.navigate("Register");
    };

    const pressHandlerLogin = () => {
        navigation.navigate("Login");
    };
    
    return (
        <SafeAreaView style={styles.flexOne}>
            <StatusBar style="light"/>
            <ImageBackground source={{uri: "https://i.imgur.com/C5SFse9.jpeg"}} style={styles.image}>
                <View style={styles.quoteContainer}>
                    <Text style={styles.quoteText}>PROGRESSIVE{"\n"}OVERLOAD{"\n"}TRACKER</Text>
                </View>
                <View>
                    <TouchableHighlight style={styles.buttonOutline} onPress={pressHandlerLogin}>
                        <Text style={styles.buttonText}>Login</Text>
                    </TouchableHighlight>
                    <TouchableHighlight style={styles.buttonOutline} onPress={pressHandlerRegister}>
                        <Text style={styles.buttonText}>Register</Text>
                    </TouchableHighlight>
                </View>
            </ImageBackground>
        </SafeAreaView>
    );
}

export default HomeScreen;