import {Platform, StyleSheet} from "react-native";
import {StatusBar} from "expo-status-bar";

const styles = StyleSheet.create({
    container: {
        flex: 1,
        paddingTop: Platform.OS === 'android' ? StatusBar.currentHeight : 0,
        backgroundColor: "#343c77",
        justifyContent: "space-between",
        padding: 3
    },
    image: {
        flex: 1,
        justifyContent: "space-between",
    },
    flexOne: {
        flex: 1
    },
    quoteContainer: {
        flexGrow: 1,
        justifyContent: "center",
        color: "white"
    },
    background: {
        backgroundColor: "rgba(0, 0, 0, 0.6)",
        paddingBottom: 10
    },
    quoteText: {
        backgroundColor: "rgba(0, 0, 0, 0.6)",
        padding: 5,
        textAlign: "center",
        color: "white",
        fontSize: 50,
        fontWeight: "bold"
    },
    buttonOutline: {
        margin: 3,
        padding: 12,
        backgroundColor: "#14213D",
        borderStyle: "solid",
        borderColor: "black",
        borderWidth: 1,
    },
    buttonText: {
        textAlign: "center",
        color: "white"
    },
    headerText: {
        color: "white",
        fontSize: 22,
        marginLeft: 5,
        fontWeight: "bold",
    },
    headerTextCenter: {
        color: "white",
        fontSize: 22,
        marginLeft: 5,
        fontWeight: "bold",
        textAlign: "center"
    },
    smallText: {
        marginLeft: 5,
        color: "white",
        fontSize: 14,
    },
    sideButtonContainer: {
        flexDirection: "row-reverse",
        justifyContent: "space-between"
    },
    halfButton: {
        width: "48.5%"
    },
    listView: {
        margin: 3
    },
    listText: {
        padding: 5,
        color: "white",
        fontSize: 15,
        textAlign: "center"
    },
    splitViewContainer: {
        justifyContent: "flex-start",
        flexDirection: "row",
    },
    splitView: {
        width: "49.5%"
    },
    workoutText: {
        color: "white",
        fontSize: 16,
        fontWeight: "bold"
    },
    setText: {
        color: "white",
        fontSize: 16,
    },
    setDataText: {
        color: "white",
        fontSize: 16,
        paddingTop: 11,
        paddingBottom: 11
    },
    smallListText: {
        padding: 5,
        color: "white",
        fontSize: 12,
        textAlign: "center"
    },
    smallHeaderText: {
        color: "white",
        fontSize: 18,
    },
});

export default styles;